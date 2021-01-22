    byte[] start = Encoding.UTF8.GetBytes("<root>");
    byte[] ending = Encoding.UTF8.GetBytes("</root>");
    
    byte[] data = File.ReadAllBytes(file.FullName);
    int bom = (data[0] == 0xEF) ? 3 : 0;
    
    using (FileStream s = File.Create(file.FullName)) {
       if (bom > 0) {
          s.Write(data, 0, bom);
       }
       s.Write(start, 0, start.Length);
       s.Write(data, bom, data.Length - bom);
       s.Write(ending, 0, ending.Length);
    }
