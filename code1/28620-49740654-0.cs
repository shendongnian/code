    //*********************************************************************************************************************************
    //
    //             Class:  BackwardReader
    //      Initial Date:  11/29/2010
    //     Last Modified:  11/29/2010
    //     Programmer(s):  Original C# Source - the_real_herminator
    //                     http://social.msdn.microsoft.com/forums/en-US/csharpgeneral/thread/9acdde1a-03cd-4018-9f87-6e201d8f5d09
    //                     VB Converstion - Blake Pell
    //
    //*********************************************************************************************************************************
    
    using System.Text;
    using System.IO;
    public class BackwardReader
    {
        private string path;
        private FileStream fs = null;
        public BackwardReader(string path)
        {
            this.path = path;
            fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            fs.Seek(0, SeekOrigin.End);
        }
        public string Readline()
        {
            byte[] line;
            byte[] text = new byte[1];
            long position = 0;
            int count;
            fs.Seek(0, SeekOrigin.Current);
            position = fs.Position;
            //do we have trailing rn?
            if (fs.Length > 1)
            {
                byte[] vagnretur = new byte[2];
                fs.Seek(-2, SeekOrigin.Current);
                fs.Read(vagnretur, 0, 2);
                if (ASCIIEncoding.ASCII.GetString(vagnretur).Equals("rn"))
                {
                    //move it back
                    fs.Seek(-2, SeekOrigin.Current);
                    position = fs.Position;
                }
            }
            while (fs.Position > 0)
            {
                text.Initialize();
                //read one char
                fs.Read(text, 0, 1);
                string asciiText = ASCIIEncoding.ASCII.GetString(text);
                //moveback to the charachter before
                fs.Seek(-2, SeekOrigin.Current);
                if (asciiText.Equals("n"))
                {
                    fs.Read(text, 0, 1);
                    asciiText = ASCIIEncoding.ASCII.GetString(text);
                    if (asciiText.Equals("r"))
                    {
                        fs.Seek(1, SeekOrigin.Current);
                        break;
                    }
                }
            }
            count = int.Parse((position - fs.Position).ToString());
            line = new byte[count];
            fs.Read(line, 0, count);
            fs.Seek(-count, SeekOrigin.Current);
            return ASCIIEncoding.ASCII.GetString(line);
        }
        public bool SOF
        {
            get
            {
                return fs.Position == 0;
            }
        }
        public void Close()
        {
            fs.Close();
        }
    }
