    string line;
            string line1;
            string line2;
            
            System.IO.StreamReader file = new System.IO.StreamReader(@"c:\test.txt");
            //walk the file line by line
            while ((line = file.ReadLine()) != null)
            {
                if(line.Contains("Ball"))
                {
                    //Once you find your search value, set line2 to the line and stop walking the file.
                    line2 = line;
                    break;
                }
                //set line1 to the line value to hold onto it if you find your search value
                line1 = line;
            }
           //Now you have both strings and you can concatenate them however you want and print them
            string s = line1 + " " + line2;
            PrintDocument p = new PrintDocument();
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(s, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
            };
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
            file.Close();
