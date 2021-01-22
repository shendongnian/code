    namespace Test
    {
        //In this case, this delegate declaration is like specifying a specific kind of function that must be used with events.
        public delegate string CallbackDemo(string str);
        class Program
        {
            public event CallbackDemo OnFoobared;
            static void Main(string[] args)
            {
    		    //this means that StrAnother is "subscribing" to the event, in other words it gets called when the event is fired
                OnFoobared += StrAnother; 
    			string substr = Strfunc();
                Console.WriteLine(substr);
                Console.ReadKey(true);
    			//this is the other use of delegates, in this case they are being used as an "anonymous function". 
    			//This one takes no parameters and returns void, and it's equivalent to the function declaration 
    			//'void myMethod() { Console.WriteLine("another use of a delegate"); }'
    			var myCode = new delegate {
    			    Console.WriteLine("another use of a delegate");
    			};
    			myCode();
                Console.ReadKey(true);
    			//the previous 4 lines are equivalent to the following however this is generally what you should use if you can
    			//its called a lambda expression but it's basically a way to toss arbitrary code around
    			//read more at http://www.developer.com/net/csharp/article.php/3598381/The-New-Lambda-Expressions-Feature-in-C-30.htm or 
    			//http://stackoverflow.com/questions/167343/c-lambda-expression-why-should-i-use-this
    			var myCode2 = () => Console.WriteLine("a lambda expression");
    			myCode2();
                Console.ReadKey(true);
            }
        
            static string Strfunc()
            {
               return OnFoobared("a use of a delegate (with an event)");  
            }
            static string StrAnother(string str)
            {
                return str.Substring(1, 3).ToString();
            }
        }
    }
