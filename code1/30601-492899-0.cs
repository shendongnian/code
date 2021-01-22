    namespace OpenXmlDocGenerator
    {
        /// <summary>
        /// Adds extensions for making the Open XML SDK and LINQ to XML easier to use.
        /// </summary>
        public static class OpenXmlExtensions
        {
            #region fields
            private static readonly XNamespace w = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
            private static readonly XName r = w + "r";
            private static readonly XName ins = w + "ins";
            private static readonly XNamespace ds = "http://schemas.openxmlformats.org/officeDocument/2006/customXml";
            #endregion
            #region methods
            /// <summary>
            /// Adds the custom XML part to the main document part.
            /// </summary>
            /// <param name="document">The main document part.</param>
            /// <param name="customXml">The custom XML.</param>
            /// <returns>The <see cref="CustomXmlPart" />.</returns>
            public static void AddCustomXmlPart(this MainDocumentPart document, XDocument customXml)
            {
                CustomXmlPart customXmlPart = document.AddNewPart<CustomXmlPart>();
                customXmlPart.PutXDocument(customXml);
            }
            /// <summary>
            /// Adds the custom XML part with a custom XML properties to the main document part.
            /// </summary>
            /// <param name="mainPart">The main document part.</param>
            /// <param name="customXml">The custom XML.</param>
            /// <param name="customXmlProperties">The custom XML properties.</param>
            public static void AddCustomXmlPart(
                this MainDocumentPart mainPart, XDocument customXml, XDocument customXmlProperties)
            {
                CustomXmlPart customXmlPart = mainPart.AddNewPart<CustomXmlPart>();
                CustomXmlPropertiesPart customXmlPropertiesPart = customXmlPart.AddNewPart<CustomXmlPropertiesPart>();
                customXmlPropertiesPart.PutXDocument(customXmlProperties);
                customXmlPart.PutXDocument(customXml);
            }
            /// <summary>
            /// Clones the specified element.
            /// </summary>
            /// <param name="element">The element.</param>
            /// <returns>The cloned <see cref="XElement" />.</returns>
            public static XElement Clone(this XElement element)
            {
                return new XElement(element.Name,
                           element.Attributes(),
                           element.Nodes().Select(n =>
                              {
                                  XElement e = n as XElement;
                                  if (e != null)
                                  {
                                      return e.Clone();
                                  }
                                  return n;
                              }
                           ),
                           (!element.IsEmpty && !element.Nodes().OfType<XText>().Any()) ? string.Empty : null
                       );
            }
            /// <summary>
            /// Fills the specified element with the provided <paramref name="entityMap"/>.
            /// </summary>
            /// <param name="element">The element.</param>
            /// <param name="entityMap">The entity map between the custom XML elements and the entity values.</param>
            /// <returns>The filled <see cref="XElement"/>.</returns>
            public static XElement Fill(this XElement element, IDictionary<string, object> entityMap)
            {
                return new XElement(element.Name,
                           element.Attributes(),
                           element.Nodes().Select(node =>
                              {
                                  XElement childElement = node as XElement;
                                  if (childElement != null)
                                  {
                                      // If the child element does not have elements,
                                      // attempt to insert the value from the entity map;
                                      // otherwise, recursively call the Fill() to find
                                      // child elements to fill.
                                      return !childElement.HasElements
                                                 ? InsertValue(childElement, entityMap)
                                                 : childElement.Fill(entityMap);
                                  }
                                   
                                  return node;
                              }
                           ),
                           (!element.IsEmpty && !element.Nodes().OfType<XText>().Any()) ? string.Empty : null
                       );
            }
            /// <summary>
            /// Gets a descendant element of the specified element the by the descendant's name.
            /// </summary>
            /// <param name="element">The element from which to find the descendant element.</param>
            /// <param name="descendantElementName">Name of the descendant element.</param>
            /// <returns>The descendant <see cref="XElement" />.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the <paramref name="element"/> is null.</exception>
            public static XElement GetDescendantByName(this XElement element, string descendantElementName)
            {
                if (element == null)
                {
                    throw new ArgumentNullException("element");
                }
                return element.Elements().DescendantsAndSelf().FirstOrDefault(e => e.Name.LocalName == descendantElementName);
            }
            /// <summary>
            /// Gets the custom XML from the main document part.
            /// </summary>
            /// <param name="mainPart">The main document part.</param>
            /// <returns>The custom XML as a <see cref="XElement" />.</returns>
            public static XElement GetCustomXml(this MainDocumentPart mainPart)
            {
                CustomXmlPart customXmlPart = mainPart.GetPartsOfType<CustomXmlPart>().FirstOrDefault();
                return customXmlPart == null ? null : customXmlPart.GetXDocument().Root;
            }
            /// <summary>
            /// Gets the XDocument from the document part.
            /// </summary>
            /// <param name="part">The document part.</param>
            /// <returns>The XDocument.</returns>
            public static XDocument GetXDocument(this OpenXmlPart part)
            {
                XDocument xdoc = part.Annotation<XDocument>();
                if (xdoc != null)
                {
                    return xdoc;
                }
                using (StreamReader streamReader = new StreamReader(part.GetStream()))
                using (XmlReader xmlReader = XmlReader.Create(streamReader))
                {
                    xdoc = XDocument.Load(xmlReader);
                }
                part.AddAnnotation(xdoc);
                return xdoc;
            }
            /// <summary>
            /// Determines whether the specified document is bindable.
            /// </summary>
            /// <param name="document">The document.</param>
            /// <returns>
            /// 	<c>true</c> if the specified document has a <see cref="CustomXmlPart" />; otherwise, <c>false</c>.
            /// </returns>
            public static bool IsBindable(this WordprocessingDocument document)
            {
                return document.MainDocumentPart.GetPartsCountOfType<CustomXmlPart>() > 0;
            }
            /// <summary>
            /// Serializes the XDocument back into the package.
            /// </summary>
            /// <param name="part">The document part.</param>
            /// <param name="xdoc">The <see cref="XDocument" />.</param>
            public static void PutXDocument(this OpenXmlPart part, XDocument xdoc)
            {
                if (xdoc != null)
                {
                    using (Stream stream = part.GetStream(FileMode.Create, FileAccess.ReadWrite))
                    using (XmlWriter partWriter = XmlWriter.Create(stream))
                    {
                        xdoc.Save(partWriter);
                    }
                }
            }
            /// <summary>
            /// Removes the custom XML parts.
            /// </summary>
            /// <param name="mainPart">The main document part.</param>
            public static void RemoveCustomXmlParts(this MainDocumentPart mainPart)
            {
                if (mainPart.CustomXmlParts.Count() > 0)
                {
                    mainPart.DeleteParts(mainPart.CustomXmlParts);
                }
            }
            /// <summary>
            /// Replaces the custom XML in the main document mainPart.
            /// </summary>
            /// <param name="mainPart">The main document part.</param>
            /// <param name="customXml">The custom XML.</param>
            public static void ReplaceCustomXml(this MainDocumentPart mainPart, XElement customXml)
            {
                if (customXml != null)
                {
                    mainPart.RemoveCustomXmlParts();
                    CustomXmlPart customXmlPart = mainPart.AddNewPart<CustomXmlPart>();
                    using (Stream stream = customXmlPart.GetStream(FileMode.Create, FileAccess.ReadWrite))
                    using (XmlWriter writer = XmlWriter.Create(stream))
                    {
                        customXml.Save(writer);
                    }   
                }
            }
            /// <summary>
            /// Translates the <paramref name="source"/> collection using the <paramref name="translate"/>,
            /// then concatenates and returns the result.
            /// </summary>
            /// <typeparam name="T">The type of the items in the source.</typeparam>
            /// <param name="source">The source.</param>
            /// <param name="translate">The translation function to perform on each item in the source.</param>
            /// <returns>The concatenated contents of the source collection.</returns>
            public static string StringConcatenate<T>(this IEnumerable<T> source, Func<T, string> translate)
            {
                return source.Aggregate(new StringBuilder(), (s, i) => s.Append(translate(i)), s => s.ToString());
            }
            /// <summary>
            /// Concatenates the items in the <paramref name="source"/> and returns the result.
            /// </summary>
            /// <param name="source">The source.</param>
            /// <returns>The concatenated contents of the source collection.</returns>
            public static string StringConcatenate(this IEnumerable<string> source)
            {
                return source.Aggregate(new StringBuilder(), (s, i) => s.Append(i), s => s.ToString());
            }
            /// <summary>
            /// Creates a bindable version of the <see cref="WordprocessingDocument" />.
            /// </summary>
            /// <param name="document">The document.</param>
            /// <returns>The <see cref="WordprocessingDocument" />.</returns>
            /// <seealso cref="http://blogs.msdn.com/ericwhite/archive/2008/10/19/creating-data-bound-content-controls-using-the-open-xml-sdk-and-linq-to-xml.aspx"/>
            public static WordprocessingDocument ToBindable(this WordprocessingDocument document)
            {
                foreach (MainDocumentPart mainPart in document.GetPartsOfType<MainDocumentPart>())
                {
                    mainPart.RemoveCustomXmlParts();
                    Guid id = Guid.NewGuid();
                    XDocument customXml = mainPart.CreateCustomXml();
                    XDocument customXmlProperties = CreateCustomXmlProperties(id);
                    mainPart.AddCustomXmlPart(customXml, customXmlProperties);
                    XDocument partXDoc = mainPart.GetXDocument();
                    AddDataBinding(partXDoc, id);
                    mainPart.PutXDocument(partXDoc);
                }
                return document;
            }
            #region --private
            /// <summary>
            /// Adds data binding to the content controls.
            /// </summary>
            /// <param name="mainDocumentXDoc">The main document <see cref="XDocument" />.</param>
            /// <param name="id">The id.</param>
            private static void AddDataBinding(XDocument mainDocumentXDoc, Guid id)
            {
                foreach (XElement sdt in mainDocumentXDoc.Descendants(w + "sdt"))
                {
                    sdt.Element(w + "sdtPr")
                        .Element(w + "placeholder")
                        .AddAfterSelf(
                        new XElement(w + "dataBinding",
                            new XAttribute(w + "xpath",
                                "/root/" + sdt.Element(w + "sdtPr")
                                    .Element(w + "tag")
                                    .Attribute(w + "val").Value),
                            new XAttribute(w + "storeItemID",
                                "{" + id.ToString().ToUpper() + "}")
                        )
                    );
                }
            }
            /// <summary>
            /// Creates the custom XML from the existing content controls.
            /// </summary>
            /// <param name="mainPart">The main document part.</param>
            /// <returns>The custom XML as a <see cref="XDocument" />.</returns>
            private static XDocument CreateCustomXml(this MainDocumentPart mainPart)
            {
                XElement customXml =
                    new XElement("root",
                        mainPart
                        .GetXDocument()
                        .Descendants(w + "sdt")
                        .Select(sdt =>
                            new XElement(
                                sdt.Element(w + "sdtPr")
                                    .Element(w + "tag")
                                    .Attribute(w + "val").Value,
                                 GetTextFromContentControl(sdt).Trim())
                        )
                    );
                return new XDocument(customXml);
            }
            /// <summary>
            /// Creates the custom XML property part contents.
            /// </summary>
            /// <param name="id">The id.</param>
            /// <returns>The contents of the custom XML properties part.</returns>
            private static XDocument CreateCustomXmlProperties(Guid id)
            {
                return new XDocument(
                           new XElement(ds + "datastoreItem",
                               new XAttribute(ds + "itemID",
                                   "{" + id.ToString().ToUpper() + "}"),
                               new XAttribute(XNamespace.Xmlns + "ds",
                                   ds.NamespaceName),
                               new XElement(ds + "schemaRefs")
                           )
                       );
            }
            /// <summary>
            /// Gets the text from content control.
            /// </summary>
            /// <param name="contentControlNode">The content control node.</param>
            /// <returns>The string representation of the value in the content control.</returns>
            static string GetTextFromContentControl(XElement contentControlNode)
            {
                return contentControlNode.Descendants(w + "p")
                    .Select(p => p.Elements()
                                     .Where(z => z.Name == r || z.Name == ins)
                                     .Descendants(w + "t")
                                     .StringConcatenate(element => (string)element) + Environment.NewLine)
                    .StringConcatenate();
            }
            /// <summary>
            /// Inserts the value from the <paramref name="entityMap"/> into the <paramref name="childElement"/>.
            /// </summary>
            /// <param name="childElement">The child element.</param>
            /// <param name="entityMap">The entity map.</param>
            private static XElement InsertValue(XElement childElement, IDictionary<string, object> entityMap)
            {
                string name = childElement.Name.LocalName;
                if (entityMap.Keys.Contains(name))
                {
                    childElement.SetValue(entityMap[name] ?? string.Empty);
                }
                else
                {
                    childElement.SetValue(string.Empty);
                }
                return childElement;
            }
            #endregion
            #endregion
        }
    }
