        /// <summary>
        /// Attempts to fill the buffer with the specified number of bytes from the
        /// stream. If there are fewer bytes left in the stream than requested then
        /// all available bytes will be read into the buffer.
        /// </summary>
        /// <param name="stream">Stream to read from.</param>
        /// <param name="buffer">Buffer to write the bytes to.</param>
        /// <param name="offset">Offset at which to write the first byte read from
        ///                      the stream.</param>
        /// <param name="length">Number of bytes to read from the stream.</param>
        /// <returns>Number of bytes read from the stream into buffer. This may be
        ///          less than requested, but only if the stream ended before the
        ///          required number of bytes were read.</returns>
        public static int FillBuffer(this Stream stream,
                                     byte[] buffer, int offset, int length)
        {
            int totalRead = 0;
            while (length > 0)
            {
                var read = stream.Read(buffer, offset, length);
                if (read == 0)
                    return totalRead;
                offset += read;
                length -= read;
                totalRead += read;
            }
            return totalRead;
        }
        /// <summary>
        /// Attempts to read the specified number of bytes from the stream. If
        /// there are fewer bytes left before the end of the stream, a shorter
        /// (possibly empty) array is returned.
        /// </summary>
        /// <param name="stream">Stream to read from.</param>
        /// <param name="length">Number of bytes to read from the stream.</param>
        public static byte[] Read(this Stream stream, int length)
        {
            byte[] buf = new byte[length];
            int read = stream.FillBuffer(buf, 0, length);
            if (read < length)
                Array.Resize(ref buf, read);
            return buf;
        }
