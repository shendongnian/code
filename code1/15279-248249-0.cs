    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Office.Interop.Word;
    using Microsoft.Office.Core;
    using System.Runtime.InteropServices;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Program().Start();
            }
    
            private void Start()
            {
                object fileName = Path.Combine(Environment.CurrentDirectory, @"NewDocument.doc");
                File.Delete(fileName.ToString());
    
                try
                {
                    WordApplication = new ApplicationClass();
                    var doc = WordApplication.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                    try
                    {
                        doc.Activate();
    
                        AddDocument(@"D:\Projects\WordTests\ConsoleApplication1\Documents\Doc1.doc", doc, false);
                        AddDocument(@"D:\Projects\WordTests\ConsoleApplication1\Documents\Doc2.doc", doc, true);
    
                        doc.SaveAs(ref fileName,
                            ref missing, ref missing, ref missing, ref missing,     ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing);
                    }
                    finally
                    {
                        doc.Close(ref missing, ref missing, ref missing);
                    }
                }
                finally
                {
                    WordApplication.Quit(ref missing, ref missing, ref missing);
                }
            }
    
            private void AddDocument(string path, Document doc, bool lastDocument)
            {
                object subDocPath = path;
                var subDoc = WordApplication.Documents.Open(ref subDocPath, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing);
                try
                {
    
                    object docStart = doc.Content.End - 1;
                    object docEnd = doc.Content.End;
    
                    object start = subDoc.Content.Start;
                    object end = subDoc.Content.End;
    
                    Range rng = doc.Range(ref docStart, ref docEnd);
                    rng.FormattedText = subDoc.Range(ref start, ref end);
    
                    if (!lastDocument)
                    {
                        InsertPageBreak(doc);
                    }
                }
                finally
                {
                    subDoc.Close(ref missing, ref missing, ref missing);
                }
            }
    
            private static void InsertPageBreak(Document doc)
            {
                object docStart = doc.Content.End - 1;
                object docEnd = doc.Content.End;
                Range rng = doc.Range(ref docStart, ref docEnd);
    
                object pageBreak = WdBreakType.wdPageBreak;
                rng.InsertBreak(ref pageBreak);
            }
    
            private ApplicationClass WordApplication { get; set; }
    
            private object missing = Type.Missing;
        }
    }
