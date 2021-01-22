    class c {
        static void Main(){
    
            string s = "class c{{static void Main(){{string s={0}{1}{0};System.Console.Write(s,(char)34,s);}}}}";
    
            System.Console.Write(s,(char)34,s); //<<-- exception on this line
    
        }
    }
