     String message = @"Read {0} bytes into the buffer.";
     String fileName = @"TEST.DAT";
     Int32 recordSize = 100;
     Byte[] buffer = new Byte[recordSize];
     using (BinaryReader br = new BinaryReader(File.OpenRead(fileName)))
     {
        br.BaseStream.Seek(2 * recordSize, SeekOrigin.Begin);
        Console.WriteLine(message, br.Read(buffer, 0, recordSize));
        Console.WriteLine(message, br.Read(buffer, 0, recordSize));
     }
     Console.ReadLine();
