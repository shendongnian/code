    using System;
    using System.Linq;
    namespace UrlParserDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                var uri = new Uri("https://www.example.com/examplePhoto/stuffs/10156664251312164/?result=33");
                var uri2 = new Uri("https://www.example.com/examplePhoto/stuffs/3323232/?result=33");
                var uri3 = new Uri("https://www.example.com/exampleVideos/stuffs_videos/3323232/?result=33");
                Console.WriteLine($"Example 1: {StripTrailingSlash(uri.Segments.Last())}");
                Console.WriteLine($"Example 2: {StripTrailingSlash(uri2.Segments.Last())}");
                Console.WriteLine($"Example 3: {StripTrailingSlash(uri3.Segments.Last())}");
            }
            private static string StripTrailingSlash(string source)
            {
                if (string.IsNullOrWhiteSpace(source))
                {
                    return "";
                }
                return source.Substring(0, source.Length - 1);
            }
        }
    }
