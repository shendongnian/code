        static void Main(string[] args)
        {
            Program p = new Program();
            p.Test();
        }
        private void Test()
        {
            Image i = Image.FromFile(@"C:\a.jpg");
            Bitmap b = new Bitmap(i);
            MemoryStream ms = new MemoryStream();
            b.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
           
            byte[] by = ms.ToArray();
            double[] db = new double[(int)(Math.Ceiling((double)by.Length / 8))];
            int startInterval = 1;
            int interval = 8;
            int k = 0;
            byte[] bys = new byte[8];
            int n = 1;
           
                for (int m = startInterval; m <= interval && m<=by.Length; m++,n++)
                {
                    bys[n-1] = by[m-1];
                    if (m == interval)
                    {
                        db[k] = BitConverter.ToDouble(bys, 0);
                        startInterval += 8;
                        interval += 8;
                        k++;
                        n = 0;
                        Array.Clear(bys, 0, bys.Length);
                    }
                    if (m == by.Length)
                    {
                        db[k] = BitConverter.ToDouble(bys, 0);
                    }
                    
                    
                }
                
            
          
        }
    }
