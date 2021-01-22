    byte[] bytes = new byte[8192]; // adjust this as needed
    int bytesRead;
    do {
        bytesRead = fsIn.Read(bytes, 0, bytes.Length);
        fsOut.Write(bytes, 0, bytesRead);
    } while (bytesRead > 0);
