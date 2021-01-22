        static void Main(string[] args)  
        {  
            Func<string, char, int> countNumberOfCharsInString = 
                 (str, c) => str.Count(character => character == c);
            var list = new List<string>() 
            { "fred-064528-NEEDED1", 
               "xxxx", 
               "frederic-84728957-NEEDED2", 
               "sam-028-NEEDED3", 
               "-----", "another-test" 
            };
            list.Where(fullString => countNumberOfCharsInString(fullString,'-') == 2)
                .ToList()
                .ForEach(s => Console.WriteLine(s.Substring(s.LastIndexOf("-")+1)));
            Console.WriteLine("Press Enter");   
            Console.ReadLine();  
        } 
