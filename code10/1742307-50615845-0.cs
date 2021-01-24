    //My code so far - not very efficient but is working.
    using Ionic.Zip;
    using Ionic.Zlib;
    
            string zipPath = "0Images.zip";
            void CountZipFiles()
            {
                using (ZipFile zip = new ZipFile(zipPath))
                {
                    totalzipFiles = zip.Count-1;
                }
            }
            Image emptyImage = Image.FromFile("emptyFemale.jpg");
            void ReadZipImage()
            {
                using (ZipFile zip = new ZipFile(zipPath))
                {
                    MemoryStream tempS = new MemoryStream();
                    for (int i = 0; i &lt; zip.Count; i++)
                    {
                        if (i == countMyZipImages)
                        {
                            label1.Text = zip[i].FileName;
                            if (zip[i].FileName.Contains(".niet"))
                            {
                                pictureBox1.Image = emptyImage;
                            }
                            else
                            {
                                zip[i].Extract(tempS);
                                pictureBox1.Image = Image.FromStream(tempS);
                            }
                        }
                    }
                }
            }
    
            int totalzipFiles = 0, countMyZipImages = 0;
            private void button2_Click(object sender, EventArgs e)
            {
                countMyZipImages--;
                if (countMyZipImages &lt; 0) countMyZipImages = totalzipFiles;
                textBox1.Text = countMyZipImages.ToString();
                ReadZipImage();
            }
            private void button3_Click(object sender, EventArgs e)
            {
                countMyZipImages++;
                if (countMyZipImages &gt; totalzipFiles) countMyZipImages = 0;
                textBox1.Text = countMyZipImages.ToString();
                ReadZipImage();
            }
----
    // and this is a HELP file for later use - hopefully will help others too. ;)
    
    How to add Ionic.Zip.dll in c#.net project and use it:
    
    To add a reference, right click (in Solution Explorer on your project) Reference folder and select Add Reference.
    Then browse and add the file Ionic.Zip.dll
    
    //Important to add this using's too after referencing.
    using Ionic.Zip;
    using Ionic.Zlib;
    
    
            private void CreateZIP_Click(object sender, EventArgs e)
            {
                using (ZipFile zip = new ZipFile())
                {
                    // add this map file into the "images" directory in the zip archive
                    zip.AddFile("c:\\images\\personal\\7440-N49th.png", "images");
                    // add the report into a different directory named "files" in the archive
                    zip.AddFile("c:\\Reports\\2008-Regional-Sales-Report.pdf", "files");
                    zip.AddFile("ReadMe.txt");
                    zip.Save("MyZipFile.zip");
                    
                    Exception ex = new Exception();
                    label1.Text = ex.Message;
                }
            }
    
    
    		//You can extract to a stream, or a fizical file ! 
            private void button5_Click(object sender, EventArgs e)
            {
                using (ZipFile zip = new ZipFile("0Images.zip"))
                {
                    MemoryStream tempS = new MemoryStream(); //stream
                    
              //{      
                    foreach (ZipEntry ze in zip)		//foreach
                    {
                        // check if you want to extract the image.name 
                        if (ze.FileName == "00002 Riley Reid.jpg")
                        {
                            ze.Extract(tempS);
                            pictureBox1.Image = Image.FromStream(tempS);
                        }
                    }
               //OR
                    for (int i = 0; i &lt; zip.Count; i++)	//for
                    {
                        if (i == countMyZipImages)
                        {
                            zip[i].Extract(tempS);
                            pictureBox1.Image = Image.FromStream(tempS);
                        }
                    }
               //}     
                    
                }
            }
