    class CallBackExample
    {
        public delegate void MyNumber();
        public static void CallMeBack()
        {
            Console.WriteLine("He/She is calling you.  Pick your phone!:)");
            Console.Read();
        }
        public static void MetYourCrush(MyNumber number)
        {
            int j;
            Console.WriteLine("is she/he interested 0/1?:");
            var i = Console.ReadLine();
            if (int.TryParse(i, out j))
            {
                var interested = (j == 0) ? false : true;
                if (interested)//event
                {
                    //call his/her number
                    number();
                }
                else
                {
                    Console.WriteLine("Nothing happened! :(");
                    Console.Read();
                }
            }
        }
        static void Main(string[] args)
        {
            MyNumber number = Program.CallMeBack;
            Console.WriteLine("You have jsut met your crush and given your number");
            MetYourCrush(number);
            Console.Read();
            Console.Read();
        }       
    }
