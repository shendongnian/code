    // Program.cs
    using System;
    using System.Text;
    using UtfUnknown;
    namespace ConsoleExample
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string filename = @"E:\new-file.txt";
                DetectDemo(filename);
            }
            /// <summary>
            /// Command line example: detect the encoding of the given file.
            /// </summary>
            /// <param name="filename">a filename</param>
            public static void DetectDemo(string filename)
            {
                // Detect from File
                DetectionResult result = CharsetDetector.DetectFromFile(filename);
                // Get the best Detection
                DetectionDetail resultDetected = result.Detected;
                // detected result may be null.
                if (resultDetected != null)
                {
                    // Get the alias of the found encoding
                    string encodingName = resultDetected.EncodingName;
                    // Get the System.Text.Encoding of the found encoding (can be null if not available)
                    Encoding encoding = resultDetected.Encoding;
                    // Get the confidence of the found encoding (between 0 and 1)
                    float confidence = resultDetected.Confidence;
                    if (encoding != null)
                    {
                        Console.WriteLine($"Detection completed: {filename}");
                        Console.WriteLine($"EncodingWebName: {encoding.WebName}{Environment.NewLine}Confidence: {confidence}");
                    }
                    else
                    {
                        Console.WriteLine($"Detection completed: {filename}");
                        Console.WriteLine($"(Encoding is null){Environment.NewLine}EncodingName: {encodingName}{Environment.NewLine}Confidence: {confidence}");
                    }
                }
                else
                {
                    Console.WriteLine($"Detection failed: {filename}");
                }
            }
        }
    }
