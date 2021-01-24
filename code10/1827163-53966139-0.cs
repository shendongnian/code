    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Threading;
    using System.Threading.Tasks;
<!---->
    public static class HashExtensions {
        public static async Task<byte[]> ComputeHashAsync(
            this HashAlgorithm hashAlgorithm, Stream stream,
            CancellationToken cancellationToken = default(CancellationToken),
            IProgress<int> progress = null,
            int bufferSize = 1024 * 1024) {
            byte[] readAheadBuffer, buffer, hash;
            int readAheadBytesRead, bytesRead;
            long size, totalBytesRead = 0;
            size = stream.Length;
            readAheadBuffer = new byte[bufferSize];
            readAheadBytesRead = await stream.ReadAsync(readAheadBuffer, 0, 
               readAheadBuffer.Length, cancellationToken);
            totalBytesRead += readAheadBytesRead;
            do {
                bytesRead = readAheadBytesRead;
                buffer = readAheadBuffer;
                readAheadBuffer = new byte[bufferSize];
                readAheadBytesRead = await stream.ReadAsync(readAheadBuffer, 0,
                    readAheadBuffer.Length, cancellationToken);
                totalBytesRead += readAheadBytesRead;
    
                if (readAheadBytesRead == 0)
                    hashAlgorithm.TransformFinalBlock(buffer, 0, bytesRead);
                else
                    hashAlgorithm.TransformBlock(buffer, 0, bytesRead, buffer, 0);
                if (progress != null)
                    progress.Report((int)(((double)totalBytesRead / size) * 100));
                if (cancellationToken.IsCancellationRequested)
                    cancellationToken.ThrowIfCancellationRequested();
            } while (readAheadBytesRead != 0);
            return hash = hashAlgorithm.Hash;
        }
    }
