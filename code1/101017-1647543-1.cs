    using System.IO;
    using System.Text;
    
    string xml = "the original data to pack";
    using (MemoryStream ms = new MemoryStream())
    {
      using (BinaryWriter bw = new BinaryWriter(ms))
      {
        byte[] data = Encodings.ASCII.GetBytes(xml);
        bw.Write((Int32)data.Length + 4); // Size of ASCII string + length (4 byte int)
        bw.Write(data);
      }
      request = ms.ToArray();
    }
