     static void Main()
        {
            string textWithDuplicates = "aaabbcccggg";
    
            Console.WriteLine(textWithDuplicates.Count());  
            var letters = new HashSet<char>(textWithDuplicates);
            Console.WriteLine(letters.Count());
    
            foreach (char c in letters) Console.Write(c);   
        }
