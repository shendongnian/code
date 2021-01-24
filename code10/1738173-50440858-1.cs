    using System;
    using System.IO;
    using System.Text;
    using SevenZip;
    namespace _7ZipWrapper
    {
        public class ProgramToModify
        {
            public static void Main()
            {
                var input = "Some string"; // Input String will pass as parameter
                var compressed = MyEncode(input);
                Console.WriteLine("Compressed String: " + compressed);
                var decodedString = myDecode(compressed);
                Console.WriteLine("Decompressed String: " + decodedString);
                Console.ReadKey();
            }
            // Returns compressed and encoded base64 string from input 
            private static String MyEncode(string input) 
            {
                // Setup the SevenZip Dll
                SevenZipCompressor.SetLibraryPath(@"C:\Temp\7za64.dll");
                SevenZipCompressor SevenZipC = new SevenZipCompressor();
                SevenZipC.CompressionMethod = CompressionMethod.Ppmd;
                SevenZipC.CompressionLevel = global::SevenZip.CompressionLevel.Ultra;
                SevenZipC.ScanOnlyWritable = true;
                var memoryStream = new MemoryStream(); // Create Memory Stream
                var streamWriter = new StreamWriter(memoryStream);
                streamWriter.Write(input); // streamWriter writes input to memoryStream
                streamWriter.Flush();
                // Compress: memoryStream -> cmpdMemoryStream
                var cmpdMemoryStream = new MemoryStream();
                SevenZipC.CompressStream(memoryStream, cmpdMemoryStream, "Optional Password Field");
                Byte[] bytes = cmpdMemoryStream.ToArray();
                return Convert.ToBase64String(bytes);
            }
            // Returns plain string from compressed and encoded input
            private static String myDecode(string input) 
            {
                // Create a memory stream from the input: base64 --> bytes --> memStream
                Byte[] compBytes = Convert.FromBase64String(input);
                MemoryStream compStreamIn = new MemoryStream(compBytes);
                SevenZipExtractor.SetLibraryPath(@"C:\Temp\7za64.dll");
                var SevenZipE = new SevenZip.SevenZipExtractor(compStreamIn, "Optional Password Field");
                var OutputStream = new MemoryStream();
                SevenZipE.ExtractFile(0, OutputStream);
                var OutputBase64 = Convert.ToBase64String(OutputStream.ToArray());
                Byte[] OutputBytes = Convert.FromBase64String(OutputBase64);
                string output = Encoding.UTF8.GetString(OutputBytes);
                return output;
            }
        }
    }
