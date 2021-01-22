     public class XmlTextReaderTest
        {
            public void RunTest()
            {
                var fs = new XmlTextReader(new Fs(@"c:\TestXml.xml"));
                while (fs.Read())
                    File.AppendAllText(@"c:\xLog.txt", "Processing node..." + Environment.NewLine);
            }
        }
    
        public class Fs : FileStream
        {
            public Fs(string path)
                : base(path, FileMode.Open)
            {
    
            }
    
            public override int Read(byte[] array, int offset, int count)
            {
                File.AppendAllText(@"c:\xLog.txt", "Reading from stream..." + Environment.NewLine);
                var ans = base.Read(array, offset, count);
                return ans;
            }
    }
