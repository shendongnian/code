    using System.IO;    
    using System.Linq; // as far as you use CF 3.5, it should be available
    
    byte[] bytes = File.ReadAllBytes(path);
    byte[] trancated = bytes.Take(bytes.Lenght - 15);
    File.WriteAllBytes(path, trancated);
