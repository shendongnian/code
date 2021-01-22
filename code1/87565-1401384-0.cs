    using System;
    
    namespace HashSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                Uri uri = new Uri(
                    "http://host.com/folder/file.jpg?code=ABC123");
    
                string hash = GetPathAndQueryHash(uri);
    
                Console.WriteLine(hash);
            }
    
            public static string GetPathAndQueryHash(Uri uri)
            {
                return uri.PathAndQuery.GetHashCode().ToString();
            }
        }
    }
