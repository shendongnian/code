    using (BinaryReader br = new BinaryReader(File.Open(FILE_PATH, FileMode.Open, FileAccess.ReadWrite)))
    {    
       int length = (int)br.BaseStream.Length;    
    
       byte[] buffer = new byte[length * 2];
       int bufferPosition = 0;
    
       while (pos < length)    
       {        
           byte b = br.ReadByte();        
           if(b < 10)
           {
              buffer[bufferPosition] = 0;
              buffer[bufferPosition + 1] = b + 0x30;
              pos++;
           }
           else
           {
              buffer[bufferPosition] = b;
              buffer[bufferPosition + 1] = br.ReadByte();
              pos += 2;
           }
           bufferPosition += 2;       
       }    
    
       Console.WriteLine(System.Text.Encoding.Unicode.GetString(buffer, 0, bufferPosition));
}
