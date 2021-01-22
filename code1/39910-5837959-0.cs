    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    //Arjun 02nd May
    namespace MergeRtf
    {
    class RTFUtils
    {
        public static string getRTFBlock(string blockName,string rtf){
        
           int i=rtf.IndexOf(@"{\"+blockName);
            int startOfBlock = i;
            //Next find the end of style sheet element tag
            Stack<char> braceHolder=new Stack<char>();
            braceHolder.Push('{');
            
            string stylesheetBlock = "";
           
            while (braceHolder.Count != 0&&i<rtf.Length) {
                i++;
                if (rtf[i] == '{') {
                    braceHolder.Push('{');
                    continue;
                }
                if (rtf[i] == '}') {
                    braceHolder.Pop();
                }
            }
            if (braceHolder.Count == 0) { 
            //encountered the ending tag for stylesheet
                stylesheetBlock = rtf.Substring(startOfBlock, i-startOfBlock+1); 
                return stylesheetBlock;
            }
            else
            {
                //Error in doc format
                throw (new Exception("Error in doc format"));
            }
           
        }
        
       
        public static string MergeRTFs(string rtf1,string rtf2,string mergingBreak){ 
            //mergingBreak is the type of break that will be sandwiched between the docs
            //get the fonttbl blocks for both the documents
            string fontTableOfDoc1 = getRTFBlock("fonttbl", rtf1);
            string fontTableOfDoc2 = getRTFBlock("fonttbl", rtf2);
            
            //get font lists
            List<string> fontList1 = ExtractRTFFonts(fontTableOfDoc1);
            List<string> fontList2 = ExtractRTFFonts(fontTableOfDoc2);
         
            //Union the font list
            IEnumerable<string> mergedfonts = fontList1.Union(fontList2);
            List<string> fontList3 = new List<string>(mergedfonts);
            string mergedFontListBlock = @"{\fonttbl";
            foreach (string font in fontList3) {
                mergedFontListBlock += font;
            }
            mergedFontListBlock += "}";
            //Find location of the fonttable in doc 1 and doc 2
            int indexOfFontTable1 = rtf1.IndexOf(@"{\fonttbl");
            int indexOfFontTable2 = rtf2.IndexOf(@"{\fonttbl");
            string rtfMerged = "";
            //Get rtf content before and after fonttable
            string headerRTF1 = rtf1.Substring(0, indexOfFontTable1);
            int endOfFontTableIndex=indexOfFontTable1 + (fontTableOfDoc1.Length-1);
            string trailerRTF1 = rtf1.Substring(endOfFontTableIndex + 1,      rtf1.LastIndexOf('}') - (endOfFontTableIndex + 1)); //-2 to remove ending } of 1st doc
            //create the first rtf with merged fontlist
            rtfMerged = headerRTF1 + mergedFontListBlock + trailerRTF1;
            //next identify trailer part after font table in rtf 2
            string trailerRTF2 = rtf2.Substring(indexOfFontTable2 + fontTableOfDoc2.Length);
            rtfMerged += mergingBreak + trailerRTF2;
            return rtfMerged;
        }
        private static List<string> ExtractRTFFonts(string fontTableBlock) {
            Stack<char> braces = new Stack<char>();
            List<string> fonts = new List<string>();
            int fontDefStart=0,fontDefLength;
            braces.Push('{');
            int i=0;
            while (braces.Count > 0 && i < fontTableBlock.Length) { 
                i++;
                if (fontTableBlock[i] == '{') {
                    braces.Push('{');
                    if (braces.Count == 2) { 
                    //means font definition brace started store the position
                        fontDefStart = i;
                    }
                    continue;
                }
                if (fontTableBlock[i] == '}') {
                    braces.Pop();
                    if (braces.Count == 1) { 
                    //means only root level brace left identifying one font definition ended
                        fontDefLength = i - fontDefStart + 1;
                        fonts.Add(fontTableBlock.Substring(fontDefStart,fontDefLength));
                    }
                }
            }
            if (braces.Count == 0)
            {
                //everything is fine then
                return fonts;
            }
            else { 
            //malformed font table passed
                throw (new Exception("Malformed font table passed"));
            }
        }
    }
    } 
