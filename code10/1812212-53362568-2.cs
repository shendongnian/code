        private void PrintBarcodeEvent_PrintPage(object sender, PrintPageEventArgs e)
        {
            int startX = 5;
            int startY = 5;
            Database db = new Database();
            db.DBOpen();
            int NBbarcode_perLine = 5;
            int numbarcode = 0;
            int barcodePerPage = 35;
            int countBarcodePerPage = 0;
            int totalcodebar = listTobePrint.Count;
            for (int i = 0; i < barcodePerPage; i++)
            {
                String code = listTobePrint[countbarcode].Code;
                String name = db.GetByValue(Database.TABLE_ITEMS, Database.CODE_ITEMS, code, 2);
                String price = db.GetByValueForInt(Database.TABLE_ITEMS, Database.CODE_ITEMS, code, 8);
                Font printFont = new Font("Arial", 10.0f);
                e.Graphics.DrawString("Phulkari by VIRSA", printFont, System.Drawing.Brushes.Black,
                  startX, startY, new StringFormat());
                int x2 = startX + 3;
                int y2 = startY + 15;
                e.Graphics.DrawImage(Util.ImageWpfToGDI(Util.GenerateBarcode(code)), x2, y2, 100, 50);
                int x3 = startX;
                int y3 = y2 + 50;
                e.Graphics.DrawString(code, printFont, System.Drawing.Brushes.Black,
                    x3, y3, new StringFormat());
                int x4 = startX;
                int y4 = y3 + 15;
                e.Graphics.DrawString(name, printFont, System.Drawing.Brushes.Black,
                   x4, y4, new StringFormat());
                int x5 = startX;
                int y5 = y4 + 15;
                e.Graphics.DrawString("Rs." + price, printFont, System.Drawing.Brushes.Black,
                   x5, y5, new StringFormat());
                numbarcode++;
                countbarcode++;
                if (numbarcode < NBbarcode_perLine)
                    startX += 150;
                else
                {
                    startX = 5;
                    startY += 150; // space between 2 barcode in vertical (upper left). you have to adjust)
                    numbarcode = 0;
                }
                if (countbarcode == totalcodebar) break;
                if (i == barcodePerPage - 1)
                {
                        db.DBClose();
                        e.HasMorePages = true;
                        return;
                }
            }
            e.HasMorePages = false;
            db.DBClose();
            listTobePrint.Clear();
        }
