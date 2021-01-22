    using Bluebird.BIP.Printer;
    ...
    this.prn1 = new Bluebird.BIP.Printer.Printer();
    if (!this.prn1.Open(0))
                {
                    MessageBox.Show("Can not open Printer", "Printer problem");
                }
    this.prn1.PrintText("sdfgidfui", 0);
    this.prn1.PrintBitmap(@"\My Documents\sample.bmp", 0);
    
    if (this.prn1.WaitUntilPrintEnd() == 1)
    {
    MessageBox.Show("No paper in Printer", "Printer problem");
                    }
                }
    this.prn1.Close();
