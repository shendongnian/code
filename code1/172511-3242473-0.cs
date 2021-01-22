    CODE
    namespace iTextSharp.text.pdf.parser{
    
        /**
         * Tool that parses the content of a PDF document.
         * @since   2.1.4
         */
        public class PdfContentReaderTool {
    
            /**
             * Shows the detail of a dictionary.
             * This is similar to the PdfLister functionality.
             * @param dic   the dictionary of which you want the detail
             * @return  a String representation of the dictionary
             */
            public static String GetDictionaryDetail(PdfDictionary dic){
                return GetDictionaryDetail(dic, 0);
            }
    
            /**
             * Shows the detail of a dictionary.
             * @param dic   the dictionary of which you want the detail
             * @param depth the depth of the current dictionary (for nested dictionaries)
             * @return  a String representation of the dictionary
             */
            public static  String GetDictionaryDetail(PdfDictionary dic, int depth){
                StringBuilder builder = new StringBuilder();
                builder.Append('(');
                IList<PdfName> subDictionaries = new List<PdfName>();
                foreach (PdfName key in dic.Keys) {
                    PdfObject val = dic.GetDirectObject(key);
                    if (val.IsDictionary())
                        subDictionaries.Add(key);
                    builder.Append(key);
                    builder.Append('=');
                    builder.Append(val);
                    builder.Append(", ");
                }
                builder.Length = builder.Length-2;
                builder.Append(')');
                foreach (PdfName pdfSubDictionaryName in subDictionaries) {
                    builder.Append('\n');
                    for (int i = 0; i < depth+1; i++){
                        builder.Append('\t');
                    }
                    builder.Append("Subdictionary ");
                    builder.Append(pdfSubDictionaryName);
                    builder.Append(" = ");
                    builder.Append(GetDictionaryDetail(dic.GetAsDict(pdfSubDictionaryName), depth+1));
                }
                return builder.ToString();
            }
    
            /**
             * Displays a summary of the entries in the XObject dictionary for the stream
             * @param resourceDic the resource dictionary for the stream
             * @return a string with the summary of the entries
             * @throws IOException
             * @since 5.0.2
             */
            public static String GetXObjectDetail(PdfDictionary resourceDic) {
                StringBuilder sb = new StringBuilder();
                
                PdfDictionary xobjects = resourceDic.GetAsDict(PdfName.XOBJECT);
                if (xobjects == null)
                    return "No XObjects";
                foreach (PdfName entryName in xobjects.Keys) {
                    PdfStream xobjectStream = xobjects.GetAsStream(entryName);
                    
                    sb.Append("------ " + entryName + " - subtype = " + xobjectStream.Get(PdfName.SUBTYPE) + " = " + xobjectStream.GetAsNumber(PdfName.LENGTH) + " bytes ------\n");
                    
                    if (!xobjectStream.Get(PdfName.SUBTYPE).Equals(PdfName.IMAGE)){
                    
                        byte[] contentBytes = ContentByteUtils.GetContentBytesFromContentObject(xobjectStream);
    
                        foreach (byte b in contentBytes) {
                            sb.Append((char)b);
                        }
            
                        sb.Append("------ " + entryName + " - subtype = " + xobjectStream.Get(PdfName.SUBTYPE) + "End of Content" + "------\n");
                    }
                }
               
                return sb.ToString();
            }
            
            /**
             * Writes information about a specific page from PdfReader to the specified output stream.
             * @since 2.1.5
             * @param reader    the PdfReader to read the page content from
             * @param pageNum   the page number to read
             * @param out       the output stream to send the content to
             * @throws IOException
             */
            public static void ListContentStreamForPage(PdfReader reader, int pageNum, TextWriter outp) {
                outp.WriteLine("==============Page " + pageNum + "====================");
                outp.WriteLine("- - - - - Dictionary - - - - - -");
                PdfDictionary pageDictionary = reader.GetPageN(pageNum);
                outp.WriteLine(GetDictionaryDetail(pageDictionary));
    
                outp.WriteLine("- - - - - XObject Summary - - - - - -");
                outp.WriteLine(GetXObjectDetail(pageDictionary.GetAsDict(PdfName.RESOURCES)));
                
                outp.WriteLine("- - - - - Content Stream - - - - - -");
                RandomAccessFileOrArray f = reader.SafeFile;
    
                byte[] contentBytes = reader.GetPageContent(pageNum, f);
                f.Close();
    
                outp.Flush();
    
                foreach (byte b in contentBytes) {
                    outp.Write((char)b);
                }
    
                outp.Flush();
                
                outp.WriteLine("- - - - - Text Extraction - - - - - -");
                String extractedText = PdfTextExtractor.GetTextFromPage(reader, pageNum, new LocationTextExtractionStrategy());
                if (extractedText.Length != 0)
                    outp.WriteLine(extractedText);
                else
                    outp.WriteLine("No text found on page " + pageNum);
    
                outp.WriteLine();
    
            }
    
            /**
             * Writes information about each page in a PDF file to the specified output stream.
             * @since 2.1.5
             * @param pdfFile   a File instance referring to a PDF file
             * @param out       the output stream to send the content to
             * @throws IOException
             */
            public static void ListContentStream(string pdfFile, TextWriter outp) {
                PdfReader reader = new PdfReader(pdfFile);
    
                int maxPageNum = reader.NumberOfPages;
    
                for (int pageNum = 1; pageNum <= maxPageNum; pageNum++){
                    ListContentStreamForPage(reader, pageNum, outp);
                }
    
            }
    
            /**
             * Writes information about the specified page in a PDF file to the specified output stream.
             * @since 2.1.5
             * @param pdfFile   a File instance referring to a PDF file
             * @param pageNum   the page number to read
             * @param out       the output stream to send the content to
             * @throws IOException
             */
            public static void ListContentStream(string pdfFile, int pageNum, TextWriter outp) {
                PdfReader reader = new PdfReader(pdfFile);
    
                ListContentStreamForPage(reader, pageNum, outp);
            }
    
            /**
             * Writes information about each page in a PDF file to the specified file, or System.out.
             * @param args
             */
            public static void Main(String[] args) {
                try{
                    if (args.Length < 1 || args.Length > 3){
                        Console.WriteLine("Usage:  PdfContentReaderTool <pdf file> [<output file>|stdout] [<page num>]");
                        return;
                    }
    
                    TextWriter writer = Console.Out;
                    if (args.Length >= 2){
                        if (!Util.EqualsIgnoreCase(args[1], "stdout")) {
                            Console.WriteLine("Writing PDF content to " + args[1]);
                            writer = new StreamWriter(args[1]);
                        }
                    }
    
                    int pageNum = -1;
                    if (args.Length >= 3){
                        pageNum = int.Parse(args[2]);
                    }
    
                    if (pageNum == -1){
                        ListContentStream(args[0], writer);
                    } else {
                        ListContentStream(args[0], pageNum, writer);
                    }
                    writer.Flush();
    
                    if (args.Length >= 2){
                        writer.Close();
                        Console.WriteLine("Finished writing content to " + args[1]);
                    }
                } catch (Exception e){
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
    /CODE
