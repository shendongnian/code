    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using PdfSharp.Pdf;
    using PdfSharp.Pdf.IO;
    using System.IO;
    
    
    namespace FolderBrowserDialogSampleInCSharp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void BrowseFolderButton_Click(object sender, EventArgs e)
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;
                // Show the FolderBrowserDialog.
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    textBox1.Text = folderDlg.SelectedPath;
                    Environment.SpecialFolder root = folderDlg.RootFolder;
    
                
                
                    
                
                var dir = textBox1.Text;
                
                File.SetAttributes(dir, FileAttributes.Normal);
                    string[] files = Directory.GetFiles(dir, "*.pdf");
                    IEnumerable<IGrouping<string, string>> groups = files.GroupBy(n => n.Split('.')[0].Split('_')[0]);
    
                    foreach (var items in groups)
                    {
                        Console.WriteLine(items.Key);
                        PdfDocument outputPDFDocument = new PdfDocument();
                        foreach (var pdfFile in items)
                        {
                            Merge(outputPDFDocument, pdfFile);
                        }
                        if (!Directory.Exists(dir + @"\Merge"))
                            Directory.CreateDirectory(dir + @"\Merge");
    
                        outputPDFDocument.Save(Path.GetDirectoryName(items.Key) + @"\Merge\" + Path.GetFileNameWithoutExtension(items.Key) + ".pdf");
                    }
                    Console.Read();
    
                    Close();
                }
                
            }
            private static void Merge(PdfDocument outputPDFDocument, string pdfFile)
            {
                PdfDocument inputPDFDocument = PdfReader.Open(pdfFile, PdfDocumentOpenMode.Import);
                outputPDFDocument.Version = inputPDFDocument.Version;
                foreach (PdfPage page in inputPDFDocument.Pages)
                {
                    outputPDFDocument.AddPage(page);
                }
            }
    
    
        }
    
      
           
    }
