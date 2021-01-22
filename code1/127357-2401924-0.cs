            FileStream fs = new FileStream("E:\\hh.txt", FileMode.Open, FileAccess.Read);
            BinaryReader read = new BinaryReader(fs);
            byte[] ch = read.ReadBytes((int)fs.Length);
            byte[] che=new byte[(int)fs.Length];
            int size = (int)fs.Length,j=0;
            for ( int i =0; i <= (size-1); i++)
            {
                if (ch[i] != '|')
                {
                    che[j] = ch[i];
                    j++;
                }
               
            }
            richTextBox1.Text = Encoding.ASCII.GetString(che);
            read.Close();
            fs.Close();
