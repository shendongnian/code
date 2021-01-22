        static void Main(string[] args)
        {
            using (TextWriter streamWriter = new StreamWriter("lineLimit.txt")) {
                String s=String.Empty;
                for(int i=0;i<1025;i++){
                    s+= i.ToString().Substring(0,1);
                }
                streamWriter.Write(s);
                streamWriter.Close();
            }
            using (TextReader streamReader = new StreamReader("lineLimit.txt"))
            {
                String s = streamReader.ReadToEnd();
                streamReader.Close();
                Console.Out.Write(s.Length);
            }
        }
