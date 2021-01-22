     public void Start(Action<string, string, string> behavior)
         try{
            var string1 = "my queue message";
            var string2 = "some string message";
            var string3 = "some other string yet;"
            behaviour(string1, string2, string3);
         }
         catch(Exception e){
           Console.WriteLine(string.Format("Oops: {0}", e.Message))
         }
     }
