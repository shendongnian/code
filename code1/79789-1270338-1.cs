    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            Uri uri;
            if (Uri.TryCreate(args[0], UriKind.Absolute, out uri))
            {
                Console.WriteLine("Host: {0}", uri.Host);
            }
            else
            {
                Console.WriteLine("Bad URI!");
            }
        }
    }
