         const int numberOfBytesToRead = 2;
         const int streamStart = 0;
         using (var stream = new MemoryStream(3))
         {
            Debug.Assert(stream.Length == 0);
            Debug.Assert(stream.Capacity == 3);
            Debug.Assert(stream.Position == 0);
            stream.Write(raw, 0, raw.Length);
            Debug.Assert(stream.Length == raw.Length);
            Debug.Assert(stream.Position == 6);
            stream.Position = streamStart;
            Debug.Assert(stream.Position == 0);
            var buffer = new byte[numberOfBytesToRead];
            var bytesRead = stream.Read(buffer, 0, buffer.Length);
            Debug.Assert(bytesRead == numberOfBytesToRead);
            Debug.Assert(stream.Length == raw.Length);
            Debug.Assert(stream.Position == numberOfBytesToRead);
            stream.Write(raw, 0, raw.Length);
            Debug.Assert(stream.Length == raw.Length+numberOfBytesToRead);
            Debug.Assert(stream.Position == raw.Length + numberOfBytesToRead);
            stream.Position = raw.Length;
            buffer = new byte[numberOfBytesToRead];
            stream.Read(buffer, 0, buffer.Length);
            var builder = new StringBuilder("|");
            foreach (var item in buffer)
               builder.Append($"{item}|");
            Debug.Assert(builder.ToString().Equals("|5|6|"));
            builder = new StringBuilder("|");
            buffer = new byte[numberOfBytesToRead+raw.Length];
            stream.Position = streamStart;
            stream.Read(buffer, 0, buffer.Length);
            foreach (var item in buffer)
               builder.Append($"{item}|");
            Debug.Assert(builder.ToString().Equals("|1|2|1|2|3|4|5|6|"));
         }
