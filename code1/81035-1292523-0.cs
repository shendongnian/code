    using System;
    using System.IO;
    using System.Text;
    class Test {
        public static void Main() {        
            using (StreamWriter output = new StreamWriter("practice.txt")) {
                string srcString = "Area = \u03A0r^2"; // PI.R.R
                // Convert the UTF-16 encoded source string to UTF-8 and ASCII.
                byte[] utf8String = Encoding.UTF8.GetBytes(srcString);
                byte[] asciiString = Encoding.ASCII.GetBytes(srcString);
            
                // Write the UTF-8 and ASCII encoded byte arrays. 
                output.WriteLine("UTF-8  Bytes: {0}",
                    BitConverter.ToString(utf8String));
                output.WriteLine("ASCII  Bytes: {0}",
                    BitConverter.ToString(asciiString));
                // Convert UTF-8 and ASCII encoded bytes back to UTF-16 encoded  
                // string and write.
                output.WriteLine("UTF-8  Text : {0}",
                    Encoding.UTF8.GetString(utf8String));
                output.WriteLine("ASCII  Text : {0}",
                    Encoding.ASCII.GetString(asciiString));
                Console.WriteLine(Encoding.UTF8.GetString(utf8String));
                Console.WriteLine(Encoding.ASCII.GetString(asciiString));
            }
        }
    }
