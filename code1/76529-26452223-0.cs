    class Program
    {
	static event Func<string, bool> TheEvent;
        static void Main(string[] args)
        {
            TheEvent += new Func<string, bool>(Program_TheEvent);
            TheEvent +=new Func<string,bool>(Program_TheEvent2);
            TheEvent += new Func<string, bool>(Program_TheEvent3);
            var r = TheEvent("s"); //r == flase (Program_TheEvent3)
        }
        static bool Program_TheEvent(string arg)
        {
            return true;
        }
        static bool Program_TheEvent2(string arg)
        {
            return true;
        }
        static bool Program_TheEvent3(string arg)
        {
            return false;
        }        
    }
