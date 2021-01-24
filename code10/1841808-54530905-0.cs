    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    namespace NummerierePDF
    {
        public partial class Form1 : Form
        {
    		string fileToOpen = string.Empty;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    			if(string.IsNullOrWhiteSpace(fileToOpen)) return;
    			
                byte[] bytes = File.ReadAllBytes(fileToOpen);
                iTextSharp.text.Font blackFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                using (MemoryStream stream = new MemoryStream())
                {
                    PdfReader reader = new PdfReader(bytes);
                    using (PdfStamper stamper = new PdfStamper(reader, stream))
                    {
                        int pages = reader.NumberOfPages;
                        for (int i = 1; i <= pages; i++)
                        {
                            ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_RIGHT, new Phrase(i.ToString(), blackFont), 568f, 15f, 0);
                        }
                    }
                    bytes = stream.ToArray();
                }
                File.WriteAllBytes(@"L:\Users\user\Documents\PDFnummerieren\PDF1.pdf", bytes);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                this.Close();
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                var FD = new System.Windows.Forms.OpenFileDialog();
                if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fileToOpen = FD.FileName;
    
                    System.IO.FileInfo File = new System.IO.FileInfo(FD.FileName);
    
    
    
                    System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
    
                }
            }
        }
    }
