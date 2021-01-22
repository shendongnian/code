    using(MemoryStream ms = new MemoryStream()) {
        const int BUFFER_SIZE = 1024;
        byte[] buffer = new byte[BUFFER_SIZE];
        int col = reader.GetOrdinal(fieldName), bytesRead, offset = 0;
        while((bytesRead = (int)reader.GetBytes(col,offset,buffer,0,BUFFER_SIZE)) > 0) {
            ms.Write(buffer, 0, bytesRead);
            offset += bytesRead;
        }
        ms.Position = 0;
        return Image.FromStream(ms);
    }
