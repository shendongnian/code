    using System.IO;
    using System.Text;
    using (var sw  = new StreamWriter(File.Open(@"c:\myfile.txt", FileMode.CreateNew), Encoding.GetEncoding("iso-8859-1"))) {
        sw.WriteLine("my text...");				
    }
