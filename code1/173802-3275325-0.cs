    FileStream fs = new FileStream("test.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string myText = string.Empty;
            while (!sr.EndOfStream)
            {
                myText += sr.ReadLine();
            }
            sr.Close();
            txtTest.Text = myText;
