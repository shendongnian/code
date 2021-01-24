        private void button1_Click(object sender, EventArgs e)
        {
            string tempPath2 = Application.StartupPath + "//" + "test.txt";
            using (var stream = File.Open(tempPath2, FileMode.Open))
            {
                using (var ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    ms.Position = 0;
                    var docx = new DocxConvert();
                        var isok = docx.Converto(ms);
                    
                }
            }
        }
