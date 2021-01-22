    using (stream) {
        FileInfo finfo = new FileInfo(transferFile.Path);
        long position = finfo.Length;
        while (position < transferFile.Length) {
            int maxRead = Math.Min(array.Length, (int)(transferFile.Length - position));
            int read = position < array.Length
                       ? streamSocket.Receive(array, maxRead, SocketFlags.None)
                       : streamSocket.Receive(array, SocketFlags.None);
            stream.Write(array, 0, read);
            position += read;
        }
    }
->
    using (stream) {
        int read = array.Length;
        while ((read = streamSocket.Receive(array, read, SocketFlags.None)) > 0) {
            stream.Write(array, 0, read);
            if ((read = streamSocket.Available) == 0) {
                break;
            }
        }
    }
