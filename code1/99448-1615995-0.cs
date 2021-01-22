    class Program
    {
            static void Main(string[] args)
            {
                char[] originalString = "This string contains the unicode character Pi(π)".ToCharArray();
                StringBuilder asAscii = new StringBuilder(); // store final ascii string and Unicode points
                foreach (char c in originalString)
                {
                    // test if char is ascii, otherwise convert to Unicode Code Point
                    int cint = Convert.ToInt32(c);
                    if (cint <= 127 && cint >= 0)
                        asAscii.Append(c);
                    else
                        asAscii.Append(String.Format("\\u{0:x4} ", cint).Trim());
                }
                Console.WriteLine("Final string: {0}", asAscii);
                Console.ReadKey();
            }
    }
