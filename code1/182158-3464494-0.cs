    class RegExReplace
    {
        static void Main()
        {
            string text = "X(P)~AK,X(MV)~AK";
    
            Console.WriteLine("text=[" + text + "]");
    
            string result = Regex.Replace(text, @"~(\w*[A-Z$])", "~AP");
    
            // Prints: [X(P)~AP,X(MV)~AP]
            Console.WriteLine("result=[" + result + "]");
    
            text = "X(PH)~B$,X(PL)~B$,X(MV)~AP";
     
            Console.WriteLine("text=[" + text + "]");
            result = Regex.Replace(text, @"~(\w*[A-Z$])", "~USD$");
    
            // Prints: [X(PH)~USD$,X(PL)~USD$,X(MV)~USD$]
            Console.WriteLine("result=[" + result + "]");
        }
    }
