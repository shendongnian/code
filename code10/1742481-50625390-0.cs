    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing.Printing;
    using System.IO;
    using System.Drawing;
    
    namespace ConsoleApp1
    {
        class Program
        {
            private static Font printFont;
            private static StreamReader streamToPrint;
    
            static void Main(string[] args)
            {
                // generate a file name as the current date/time in unix timestamp format
                string fileName = (string)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString();
    
                // the directory to store the output.
                string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                printFont = new Font("Arial", 10);
    
                try
                {
                    streamToPrint = new StreamReader
                        ("C:\\Users\\RaikolAmaro\\Desktop\\lachy.txt");
    
                    // initialize PrintDocument object
                    PrintDocument doc = new PrintDocument
                    {
                        PrinterSettings = new PrinterSettings
                        {
                            // set the printer to 'Microsoft Print to PDF'
                            PrinterName = "Microsoft Print to PDF",
    
                            // tell the object this document will print to file
                            PrintToFile = true,
    
                            // set the filename to whatever you like (full path)
                            PrintFileName = Path.Combine(directory, fileName + ".pdf"),
                        }
                    };
                    
                    doc.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                    doc.Print();
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
    
            private static void pd_PrintPage(object sender, PrintPageEventArgs ev)
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                String line = null;
    
                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height /
                               printFont.GetHeight(ev.Graphics);
    
                // Iterate over the file, printing each line.
                while (count < linesPerPage &&
                       ((line = streamToPrint.ReadLine()) != null))
                {
                    yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                    ev.Graphics.DrawString(line, printFont, Brushes.Black,
                        leftMargin, yPos, new StringFormat());
                    count++;
                }
    
                // If more lines exist, print another page.
                if (line != null)
                    ev.HasMorePages = true;
                else
                    ev.HasMorePages = false;
            }
        }
    }
