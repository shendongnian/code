    const int LengthPadding = 16
    using (FileStream combinedFile = File.Open(...))
    using (var binReader = new BinaryReader(combinedFile)) {
        while(!combinedFile.EOF) {
            char[] segmentLengthChars = binReader.ReadChars(16);
            long segmentLength = long.Parse(new string(segmentLengthChars));
            binReader.ReadChars(2);  //Skip the newline
    
            var bytes = new byte[segmentLength];
            long totalRead = 0;
            while(bytesRead < segmentLength) {
                int read = combinedFile.Read(bytes, totalRead, Math.Min(4096, segmentLength - totalRead));
                if (read == 0)
                    throw new InvalidDataException();
            }
            yield return new MemoryStream(bytes);
        }
    }
