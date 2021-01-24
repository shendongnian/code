    using (System.IO.Stream stream = response.GetResponseStream()) {
        while (true) {
            // 3-byte buffer
            byte[] buffer = new byte[3];
            int offset = 0;
            // this block of code reliably reads 3 bytes from response stream
            while (offset < buffer.Length) {
                int read = await stream.ReadAsync(buffer, offset, buffer.Length - offset);
                if (read == 0)
                    throw new System.IO.EndOfStreamException();
                offset += read;
            }
            // convert to text with UTF-8 (for example) encoding
            // need to use encoding in which server sends
            var progressText = Encoding.UTF8.GetString(buffer);
            // report progress somehow
            Console.WriteLine(progressText);
            if (progressText == "100") // done, json will follow
                break;
        }
        // if JsonValue has async api (like LoadAsync) - use that instead of
        // Task.Run. Otherwise, in UI application, Task.Run is fine
        JsonValue jsonDoc = await Task.Run(() => JsonValue.Load(stream));
        return jsonDOc;
    }
