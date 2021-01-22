    using System;
    
    public class Test
    {
        static void Main()
        {
            string text = "http://mysite.com/testing/testingPages/area/ten/p1.aspx";
            Uri uri = new Uri(text);
            // Prints http://mysite.com
            Console.WriteLine(uri.GetLeftPart(UriPartial.Authority));
        }
    }
