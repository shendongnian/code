    using (FileStream combinedFile = File.Open(...))
    using (var binReader = new BinaryReader(combinedFile)) {
        while(!combinedFile.EOF) {
            long segmentLength = binReader.ReadInt64();
    
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
