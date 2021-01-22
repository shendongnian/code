    using System;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;
    using NUnit.Framework;
    using Ionic.Zlib;
    using ICSharpCode.SharpZipLib.GZip;
    
    namespace ZipTests
    {
        [TestFixture]
        public class ZipTests
        {
            MemoryStream input, compressed, decompressed;
            Stream compressor;
            int inputSize;
            Stopwatch timer;
    
            public ZipTests()
            {
                string testFile = "TestFile.pdf";
                using(var file = File.OpenRead(testFile))
                {
                    inputSize = (int)file.Length;
                    Console.WriteLine("Reading " + inputSize + " from " + testFile);
                    var ms = new MemoryStream(inputSize);
                    file.Read(ms.GetBuffer(), 0, inputSize);
                    ms.Position = 0;
                    input = ms;
                }
                compressed = new MemoryStream();
            }
    
            void StartCompression()
            {
                Console.WriteLine("Using " + compressor.GetType() + ":");
                GC.Collect(2, GCCollectionMode.Forced); // Start fresh
                timer = Stopwatch.StartNew();
            }
    
            public void EndCompression()
            {
                timer.Stop();
                Console.WriteLine("  took " + timer.Elapsed
                    + " to compress " + inputSize.ToString("#,0") + " bytes into "
                    + compressed.Length.ToString("#,0"));
                decompressed = new MemoryStream(inputSize);
                compressed.Position = 0; // Rewind!
                timer.Restart();
            }
    
            public void AfterDecompression()
            {
                timer.Stop();
                Console.WriteLine("  then " + timer.Elapsed + " to decompress.");
                Assert.AreEqual(inputSize, decompressed.Length);
                Assert.AreEqual(input.GetBuffer(), decompressed.GetBuffer());
                input.Dispose();
                compressed.Dispose();
                decompressed.Dispose();
            }
    
            [Test]
            public void TestGZipStream()
            {
                compressor = new System.IO.Compression.GZipStream(compressed, System.IO.Compression.CompressionMode.Compress, true);
                StartCompression();
                compressor.Write(input.GetBuffer(), 0, inputSize);
                compressor.Close();
    
                EndCompression();
    
                var decompressor = new System.IO.Compression.GZipStream(compressed, System.IO.Compression.CompressionMode.Decompress, true);
                decompressor.CopyTo(decompressed);
    
                AfterDecompression();
            }
    
            [Test]
            public void TestDotNetZip()
            {
                compressor = new Ionic.Zlib.GZipStream(compressed, Ionic.Zlib.CompressionMode.Compress, true);
                StartCompression();
                compressor.Write(input.GetBuffer(), 0, inputSize);
                compressor.Close();
    
                EndCompression();
    
                var decompressor = new Ionic.Zlib.GZipStream(compressed,
                                        Ionic.Zlib.CompressionMode.Decompress, true);
                decompressor.CopyTo(decompressed);
    
                AfterDecompression();
            }
    
            [Test]
            public void TestSharpZlib()
            {
                compressor = new ICSharpCode.SharpZipLib.GZip.GZipOutputStream(compressed)
                { IsStreamOwner = false };
                StartCompression();
                compressor.Write(input.GetBuffer(), 0, inputSize);
                compressor.Close();
    
                EndCompression();
    
                var decompressor = new ICSharpCode.SharpZipLib.GZip.GZipInputStream(compressed);
                decompressor.CopyTo(decompressed);
    
                AfterDecompression();
            }
    
            static void Main()
            {
                Console.WriteLine("Running CLR version " + Environment.Version +
                    " on " + Environment.OSVersion);
                Assert.AreEqual(1,1); // Preload NUnit
                new ZipTests().TestGZipStream();
                new ZipTests().TestDotNetZip();
                new ZipTests().TestSharpZlib();
            }
        }
    }
