        private void button1_Click(object sender, EventArgs e)
        {
            byte[] lnBuffer;
            byte[] lnFile;
            HttpWebRequest lxRequest = (HttpWebRequest)WebRequest.Create("http://www.productimageswebsite.com/images/stock_jpgs/34891.jpg");
            using (HttpWebResponse lxResponse = (HttpWebResponse)lxRequest.GetResponse())
            {
                using (BinaryReader lxBR = new BinaryReader(lxResponse.GetResponseStream()))
                {
                    using (MemoryStream lxMS = new MemoryStream())
                    {
                        lnBuffer = lxBR.ReadBytes(1024);
                        while (lnBuffer.Length > 0)
                        {
                            lxMS.Write(lnBuffer, 0, lnBuffer.Length);
                            lnBuffer = lxBR.ReadBytes(1024);
                        }
                        lnFile = new byte[(int)lxMS.Length];
                        lxMS.Position = 0;
                        lxMS.Read(lnFile, 0, lnFile.Length);
                    }
                }
            }
            using (System.IO.FileStream lxFS = new FileStream("34891.jpg", FileMode.Create))
            {
                lxFS.Write(lnFile, 0, lnFile.Length);
            }
            MessageBox.Show("done");
        }
