        static void Main(string[] args)
        {
            string inputFilename = args[0];
            int startIndex = int.Parse(args[1]);
            string newText = args[2];
            using (FileStream fs = new FileStream(inputFilename, FileMode.Open, FileAccess.Write))
            {
                fs.Position = startIndex;
                byte[] newTextBytes = Encoding.ASCII.GetBytes(newText);
                fs.Write(newTextBytes, 0, newTextBytes.Length);
            }
        }
