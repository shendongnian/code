    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Majestic12;
    using System.IO;
    using System.Xml.Linq;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    namespace Majestic12ToXml {
    public class Majestic12ToXml {
        static public IEnumerable<XNode> ConvertNodesToXml(byte[] htmlAsBytes) {
            HTMLparser parser = OpenParser();
            parser.Init(htmlAsBytes);
            XElement currentNode = new XElement("document");
            HTMLchunk m12chunk = null;
            int xmlnsAttributeIndex = 0;
            string originalHtml = "";
            while ((m12chunk = parser.ParseNext()) != null) {
                try {
                    Debug.Assert(!m12chunk.bHashMode);  // popular default for Majestic-12 setting
                    XNode newNode = null;
                    XElement newNodesParent = null;
                    switch (m12chunk.oType) {
                        case HTMLchunkType.OpenTag:
                            // Tags are added as a child to the current tag, 
                            // except when the new tag implies the closure of 
                            // some number of ancestor tags.
                            newNode = ParseTagNode(m12chunk, originalHtml, ref xmlnsAttributeIndex);
                            if (newNode != null) {
                                currentNode = FindParentOfNewNode(m12chunk, originalHtml, currentNode);
                                newNodesParent = currentNode;
                                newNodesParent.Add(newNode);
                                currentNode = newNode as XElement;
                            }
                            break;
                        case HTMLchunkType.CloseTag:
                            if (m12chunk.bEndClosure) {
                                newNode = ParseTagNode(m12chunk, originalHtml, ref xmlnsAttributeIndex);
                                if (newNode != null) {
                                    currentNode = FindParentOfNewNode(m12chunk, originalHtml, currentNode);
                                    newNodesParent = currentNode;
                                    newNodesParent.Add(newNode);
                                }
                            }
                            else {
                                XElement nodeToClose = currentNode;
                                string m12chunkCleanedTag = CleanupTagName(m12chunk.sTag, originalHtml);
                                while (nodeToClose != null && nodeToClose.Name.LocalName != m12chunkCleanedTag)
                                    nodeToClose = nodeToClose.Parent;
                                if (nodeToClose != null)
                                    currentNode = nodeToClose.Parent;
                                Debug.Assert(currentNode != null);
                            }
                            break;
                        case HTMLchunkType.Script:
                            newNode = new XElement("script", "REMOVED");
                            newNodesParent = currentNode;
                            newNodesParent.Add(newNode);
                            break;
                        case HTMLchunkType.Comment:
                            newNodesParent = currentNode;
                            if (m12chunk.sTag == "!--")
                                newNode = new XComment(m12chunk.oHTML);
                            else if (m12chunk.sTag == "![CDATA[")
                                newNode = new XCData(m12chunk.oHTML);
                            else
                                throw new Exception("Unrecognized comment sTag");
                            newNodesParent.Add(newNode);
                            break;
                        case HTMLchunkType.Text:
                            currentNode.Add(m12chunk.oHTML);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e) {
                    var wrappedE = new Exception("Error using Majestic12.HTMLChunk, reason: " + e.Message, e);
                    // the original html is copied for tracing/debugging purposes
                    originalHtml = new string(htmlAsBytes.Skip(m12chunk.iChunkOffset)
                        .Take(m12chunk.iChunkLength)
                        .Select(B => (char)B).ToArray()); 
                    
                    wrappedE.Data.Add("source", originalHtml);
                    throw wrappedE;
                }
            }
            while (currentNode.Parent != null)
                currentNode = currentNode.Parent;
            return currentNode.Nodes();
        }
        static XElement FindParentOfNewNode(Majestic12.HTMLchunk m12chunk, string originalHtml, XElement nextPotentialParent) {
            string m12chunkCleanedTag = CleanupTagName(m12chunk.sTag, originalHtml);
            XElement discoveredParent = null;
            // Get a list of all ancestors
            List<XElement> ancestors = new List<XElement>();
            XElement ancestor = nextPotentialParent;
            while (ancestor != null) {
                ancestors.Add(ancestor);
                ancestor = ancestor.Parent;
            }
            
            // Check if the new tag implies a previous tag was closed.
            if ("form" == m12chunkCleanedTag) {
                discoveredParent = ancestors
                    .Where(XE => m12chunkCleanedTag == XE.Name)
                    .Take(1)
                    .Select(XE => XE.Parent)
                    .FirstOrDefault();
            }
            else if ("td" == m12chunkCleanedTag) {
                discoveredParent = ancestors
                    .TakeWhile(XE => "tr" != XE.Name)
                    .Where(XE => m12chunkCleanedTag == XE.Name)
                    .Take(1)
                    .Select(XE => XE.Parent)
                    .FirstOrDefault();
            }
            else if ("tr" == m12chunkCleanedTag) {
                discoveredParent = ancestors
                    .TakeWhile(XE => !("table" == XE.Name
                                        || "thead" == XE.Name
                                        || "tbody" == XE.Name
                                        || "tfoot" == XE.Name))
                    .Where(XE => m12chunkCleanedTag == XE.Name)
                    .Take(1)
                    .Select(XE => XE.Parent)
                    .FirstOrDefault();
            }
            else if ("thead" == m12chunkCleanedTag
                      || "tbody" == m12chunkCleanedTag
                      || "tfoot" == m12chunkCleanedTag) {
                discoveredParent = ancestors
                    .TakeWhile(XE => "table" != XE.Name)
                    .Where(XE => m12chunkCleanedTag == XE.Name)
                    .Take(1)
                    .Select(XE => XE.Parent)
                    .FirstOrDefault();
            }
            return discoveredParent ?? nextPotentialParent;
        }
        static string CleanupTagName(string originalName, string originalHtml) {
            string tagName = originalName;
            tagName = tagName.TrimStart(new char[] { '?' });  // for nodes <?xml >
            if (tagName.Contains(':'))
                tagName = tagName.Substring(tagName.LastIndexOf(':') + 1);
            return tagName;
        }
        static readonly Regex _startsAsNumeric = new Regex(@"^[0-9]", RegexOptions.Compiled);
        static bool TryCleanupAttributeName(string originalName, ref int xmlnsIndex, out string result) {
            result = null;
            string attributeName = originalName;
            if (string.IsNullOrEmpty(originalName))
                return false;
            if (_startsAsNumeric.IsMatch(originalName))
                return false;
            //
            // transform xmlns attributes so they don't actually create any XML namespaces
            //
            if (attributeName.ToLower().Equals("xmlns")) {
                attributeName = "xmlns_" + xmlnsIndex.ToString(); ;
                xmlnsIndex++;
            }
            else {
                if (attributeName.ToLower().StartsWith("xmlns:")) {
                    attributeName = "xmlns_" + attributeName.Substring("xmlns:".Length);
                }   
                //
                // trim trailing \"
                //
                attributeName = attributeName.TrimEnd(new char[] { '\"' });
                attributeName = attributeName.Replace(":", "_");
            }
            result = attributeName;
            return true;
        }
        static Regex _weirdTag = new Regex(@"^<!\[.*\]>$");       // matches "<![if !supportEmptyParas]>"
        static Regex _aspnetPrecompiled = new Regex(@"^<%.*%>$"); // matches "<%@ ... %>"
        static Regex _shortHtmlComment = new Regex(@"^<!-.*->$"); // matches "<!-Extra_Images->"
        static XElement ParseTagNode(Majestic12.HTMLchunk m12chunk, string originalHtml, ref int xmlnsIndex) {
            if (string.IsNullOrEmpty(m12chunk.sTag)) {
                if (m12chunk.sParams.Length > 0 && m12chunk.sParams[0].ToLower().Equals("doctype"))
                    return new XElement("doctype");
                if (_weirdTag.IsMatch(originalHtml))
                    return new XElement("REMOVED_weirdBlockParenthesisTag");
                if (_aspnetPrecompiled.IsMatch(originalHtml))
                    return new XElement("REMOVED_ASPNET_PrecompiledDirective");
                if (_shortHtmlComment.IsMatch(originalHtml))
                    return new XElement("REMOVED_ShortHtmlComment");
                // Nodes like "<br <br>" will end up with a m12chunk.sTag==""...  We discard these nodes.
                return null;
            }
            string tagName = CleanupTagName(m12chunk.sTag, originalHtml);
            XElement result = new XElement(tagName);
            List<XAttribute> attributes = new List<XAttribute>();
            for (int i = 0; i < m12chunk.iParams; i++) {
                if (m12chunk.sParams[i] == "<!--") {
                    // an HTML comment was embedded within a tag.  This comment and its contents
                    // will be interpreted as attributes by Majestic-12... skip this attributes
                    for (; i < m12chunk.iParams; i++) {
                        if (m12chunk.sTag == "--" || m12chunk.sTag == "-->")
                            break;
                    }
                    continue;
                }
                if (m12chunk.sParams[i] == "?" && string.IsNullOrEmpty(m12chunk.sValues[i]))
                    continue;
                string attributeName = m12chunk.sParams[i];
                if (!TryCleanupAttributeName(attributeName, ref xmlnsIndex, out attributeName))
                    continue;
                attributes.Add(new XAttribute(attributeName, m12chunk.sValues[i]));
            }
            // If attributes are duplicated with different values, we complain.
            // If attributes are duplicated with the same value, we remove all but 1.
            var duplicatedAttributes = attributes.GroupBy(A => A.Name).Where(G => G.Count() > 1);
            foreach (var duplicatedAttribute in duplicatedAttributes) {
                if (duplicatedAttribute.GroupBy(DA => DA.Value).Count() > 1)
                    throw new Exception("Attribute value was given different values");
                attributes.RemoveAll(A => A.Name == duplicatedAttribute.Key);
                attributes.Add(duplicatedAttribute.First());
            }
            result.Add(attributes);
            return result;
        }
        static HTMLparser OpenParser() {
            HTMLparser oP = new HTMLparser();
            // The code+comments in this function are from the Majestic-12 sample documentation.
            // ...
            // This is optional, but if you want high performance then you may
            // want to set chunk hash mode to FALSE. This would result in tag params
            // being added to string arrays in HTMLchunk object called sParams and sValues, with number
            // of actual params being in iParams. See code below for details.
            //
            // When TRUE (and its default) tag params will be added to hashtable HTMLchunk (object).oParams
            oP.SetChunkHashMode(false);
            // if you set this to true then original parsed HTML for given chunk will be kept - 
            // this will reduce performance somewhat, but may be desireable in some cases where
            // reconstruction of HTML may be necessary
            oP.bKeepRawHTML = false;
            // if set to true (it is false by default), then entities will be decoded: this is essential
            // if you want to get strings that contain final representation of the data in HTML, however
            // you should be aware that if you want to use such strings into output HTML string then you will
            // need to do Entity encoding or same string may fail later
            oP.bDecodeEntities = true;
            // we have option to keep most entities as is - only replace stuff like &nbsp; 
            // this is called Mini Entities mode - it is handy when HTML will need
            // to be re-created after it was parsed, though in this case really
            // entities should not be parsed at all
            oP.bDecodeMiniEntities = true;
            if (!oP.bDecodeEntities && oP.bDecodeMiniEntities)
                oP.InitMiniEntities();
            // if set to true, then in case of Comments and SCRIPT tags the data set to oHTML will be
            // extracted BETWEEN those tags, rather than include complete RAW HTML that includes tags too
            // this only works if auto extraction is enabled
            oP.bAutoExtractBetweenTagsOnly = true;
            // if true then comments will be extracted automatically
            oP.bAutoKeepComments = true;
            // if true then scripts will be extracted automatically: 
            oP.bAutoKeepScripts = true;
            // if this option is true then whitespace before start of tag will be compressed to single
            // space character in string: " ", if false then full whitespace before tag will be returned (slower)
            // you may only want to set it to false if you want exact whitespace between tags, otherwise it is just
            // a waste of CPU cycles
            oP.bCompressWhiteSpaceBeforeTag = true;
            // if true (default) then tags with attributes marked as CLOSED (/ at the end) will be automatically
            // forced to be considered as open tags - this is no good for XML parsing, but I keep it for backwards
            // compatibility for my stuff as it makes it easier to avoid checking for same tag which is both closed
            // or open
            oP.bAutoMarkClosedTagsWithParamsAsOpen = false;
            return oP;
        }
    }
    }  
