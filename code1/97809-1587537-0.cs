    int chunkSize = 1024;
    int sent = 0
    int total = reader.Length;
    DateTime started = DateTime.Now;
    while (reader.Position < reader.Length)
    {
        byte[] buffer = new byte[
            Math.Min(chunkSize, reader.Length - reader.Position)];
        readBytes = reader.Read(buffer, 0, buffer.Length);
        // send data packet
        sent += readBytes;
        TimeSpan elapsedTime = DateTime.Now - started;
        TimeSpan estimatedTime = 
            TimeSpan.FromSeconds(
                (total - sent) / 
                ((double)sent  / elapsedTime.TotalSeconds));
    }
