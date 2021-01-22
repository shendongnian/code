     System.IO.MemoryStream stm = new System.IO.MemoryStream( buf, 0, buf.Length );
     System.IO.BinaryReader rdr = new System.IO.BinaryReader( stm );
     int bodyLen = xxx;
     byte[] head = rdr.ReadBytes(8)
     byte[] body = rdr.ReadBytes(bodyLen );
     byte[] foot = rdr.ReadBytes(buf.Length-bodylen-8);
     
     
