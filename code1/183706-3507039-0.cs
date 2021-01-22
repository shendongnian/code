     static void Main()
        {
            // A.
            // Example strings with multiple whitespaces.
            string s1 = "He saw   a cute\tdog.";
            string s2 = "There\n\twas another sentence.";
    
            // B.
            // Create the Regex.
            Regex r = new Regex(@"\s+");
    
            // C.
            // Strip multiple spaces.
            string s3 = r.Replace(s1, @" ");
            Console.WriteLine(s3);
    
            // D.
            // Strip multiple spaces.
            string s4 = r.Replace(s2, @" ");
            Console.WriteLine(s4);
            Console.ReadLine();
        }
