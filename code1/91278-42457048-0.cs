    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace System
    {
        
        static class StreamExtensions
        {
            /// <summary>
            /// Advances the supplied stream until the given searchBytes are found, without advancing too far (consuming any bytes from the stream after the searchBytes are found).
            /// Regarding efficiency, if the stream is network or file, then MEMORY/CPU optimisations will be of little consequence here.
            /// </summary>
            /// <param name="stream">The stream to search in</param>
            /// <param name="searchBytes">The byte sequence to search for</param>
            /// <returns></returns>
            public static int ScanUntilFound(this Stream stream, byte[] searchBytes)
            {
                // For this class code comments, a common example is assumed:
                // searchBytes are {1,2,3,4} or 1234 for short
                // # means value that is outside of search byte sequence
    
                byte[] streamBuffer = new byte[searchBytes.Length];
                int nextRead = searchBytes.Length;
                int totalScannedBytes = 0;
    
                while (true)
                {
                    FillBuffer(stream, streamBuffer, nextRead);
                    totalScannedBytes += nextRead; //this is only used for final reporting of where it was found in the stream
    
                    if (ArraysMatch(searchBytes, streamBuffer, 0))
                        return totalScannedBytes; //found it
    
                    nextRead = FindPartialMatch(searchBytes, streamBuffer);
                }
            }
    
            /// <summary>
            /// Check all offsets, for partial match. 
            /// </summary>
            /// <param name="searchBytes"></param>
            /// <param name="streamBuffer"></param>
            /// <returns>The amount of bytes which need to be read in, next round</returns>
            static int FindPartialMatch(byte[] searchBytes, byte[] streamBuffer)
            {
                // 1234 = 0 - found it. this special case is already catered directly in ScanUntilFound            
                // #123 = 1 - partially matched, only missing 1 value
                // ##12 = 2 - partially matched, only missing 2 values
                // ###1 = 3 - partially matched, only missing 3 values
                // #### = 4 - not matched at all
    
                for (int i = 1; i < searchBytes.Length; i++)
                {
                    if (ArraysMatch(searchBytes, streamBuffer, i))
                    {
                        // EG. Searching for 1234, have #123 in the streamBuffer, and [i] is 1
                        // Output: 123#, where # will be read using FillBuffer next. 
                        Array.Copy(streamBuffer, i, streamBuffer, 0, searchBytes.Length - i);
                        return i; //if an offset of [i], makes a match then only [i] bytes need to be read from the stream to check if there's a match
                    }
                }
    
                return 4;
            }
    
            /// <summary>
            /// Reads bytes from the stream, making sure the requested amount of bytes are read (streams don't always fulfill the full request first time)
            /// </summary>
            /// <param name="stream">The stream to read from</param>
            /// <param name="streamBuffer">The buffer to read into</param>
            /// <param name="bytesNeeded">How many bytes are needed. If less than the full size of the buffer, it fills the tail end of the streamBuffer</param>
            static void FillBuffer(Stream stream, byte[] streamBuffer, int bytesNeeded)
            {
                // EG1. [123#] - bytesNeeded is 1, when the streamBuffer contains first three matching values, but now we need to read in the next value at the end 
                // EG2. [####] - bytesNeeded is 4
    
                var bytesAlreadyRead = streamBuffer.Length - bytesNeeded; //invert
                while (bytesAlreadyRead < streamBuffer.Length)
                {
                    bytesAlreadyRead += stream.Read(streamBuffer, bytesAlreadyRead, streamBuffer.Length - bytesAlreadyRead);
                }
            }
    
            /// <summary>
            /// Checks if arrays match exactly, or with offset. 
            /// </summary>
            /// <param name="searchBytes">Bytes to search for. Eg. [1234]</param>
            /// <param name="streamBuffer">Buffer to match in. Eg. [#123] </param>
            /// <param name="startAt">When this is zero, all bytes are checked. Eg. If this value 1, and it matches, this means the next byte in the stream to read may mean a match</param>
            /// <returns></returns>
            static bool ArraysMatch(byte[] searchBytes, byte[] streamBuffer, int startAt)
            {
                for (int i = 0; i < searchBytes.Length - startAt; i++)
                {
                    if (searchBytes[i] != streamBuffer[i + startAt])
                        return false;
                }
                return true;
            }
        }
    }
