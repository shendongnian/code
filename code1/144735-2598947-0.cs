    using System;
    using System.IO;
    
    public class BinaryFileTest {
    
        private static void Main() {
            FileStream fs = new FileStream("test.dat", FileMode.Create);
            BinaryWriter w = new BinaryWriter(fs);
    
            w.Write(1.2M);
            w.Write("string");
            w.Write("string 2");
            w.Write('!');
            w.Flush();
            w.Close();
            fs.Close();
    
            fs = new FileStream("test.dat", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            Console.WriteLine(sr.ReadToEnd());
            fs.Position = 0;
            BinaryReader br = new BinaryReader(fs);
            Console.WriteLine(br.ReadDecimal());
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadChar());
            fs.Close();
    
        }
    }
