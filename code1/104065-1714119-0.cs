    using System;
    using System.Xml.Linq;
    
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    
    namespace LockDoc
    {
        /// <summary>
        /// Manipulates modification permissions of an OpenXML document.
        /// </summary>
        class Program
        {
            /// <summary>
            /// Locks/Unlocks an OpenXML document.
            /// </summary>
            /// <param name="args"></param>
            static void Main(string[] args)
            {
                if (args.Length != 2)
                {
                    Console.WriteLine("Usage: lockdoc lock|unlock filename.docx");
                    return;
                }
    
                bool isLock = false;
                if (args[0].Equals("lock", StringComparison.OrdinalIgnoreCase))
                {
                    isLock = true;
                }
                else if (!args[0].Equals("unlock", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Error.WriteLine("Wrong action!");
                    return;
                }
    
                WordprocessingDocument doc = WordprocessingDocument.Open(args[1], true);
                doc.ExtendedFilePropertiesPart.Properties.DocumentSecurity =
                    new DocumentFormat.OpenXml.ExtendedProperties.DocumentSecurity
                    (isLock ? "8" : "0");
                doc.ExtendedFilePropertiesPart.Properties.Save();
    
                DocumentProtection dp =
                    doc.MainDocumentPart.DocumentSettingsPart
                    .Settings.ChildElements.First<DocumentProtection>();
                if (dp != null)
                {
                    dp.Remove();
                }
    
                if (isLock)
                {
                    dp = new DocumentProtection();
                    dp.Edit = DocumentProtectionValues.Comments;
                    dp.Enforcement = DocumentFormat.OpenXml.Wordprocessing.BooleanValues.One;
    
                    doc.MainDocumentPart.DocumentSettingsPart.Settings.AppendChild(dp);
                }
    
                doc.MainDocumentPart.DocumentSettingsPart.Settings.Save();
    
                doc.Close();
            }
        }
    }
