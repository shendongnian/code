     static byte[] ReadNextLine(FileStream fs)
            {
                byte[] nl = new byte[] {(byte) Environment.NewLine[0],(byte) Environment.NewLine[1] };
                List<byte> ll = new List<byte>();
                bool lineFound = false;
                while (!lineFound)
                {
                    byte b = (byte)fs.ReadByte();
                    if ((int)b == -1) break;
                    ll.Add(b);
                    if (b == nl[0]){
                        b = (byte)fs.ReadByte();
                        ll.Add(b);
                        if (b == nl[1]) lineFound = true;
                    }
                }
              return  ll.Count ==0?null: ll.ToArray();
            }
           static void Main(string[] args)
           {
              
                using (FileStream fs = new FileStream(@"c:\70-528\junk.txt", FileMode.Open, FileAccess.ReadWrite))
                {
                   int replaceLine=1231;
                   byte[] b = null;
                   int lineCount=1;
                   while (lineCount<replaceLine && (b=ReadNextLine(fs))!=null ) lineCount++;//Skip Lines
                  
                   long seekPos = fs.Position;
                   b = ReadNextLine(fs);
                   fs.Seek(seekPos, 0);
                  string line=new string(b.Select(x=>(char)x).ToArray());
                  line = line.Replace("Text1", "Text2");
                    b=line.ToCharArray().Select(x=>(byte)x).ToArray();
                    fs.Write(b, 0, b.Length);
                 
                }
    
            }
