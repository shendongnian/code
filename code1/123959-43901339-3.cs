    Dedication to LightStriker:  
    Sample Code:
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
            Console.WriteLine("You have just met your crush and given your number");
            MetYourCrush(number);
            Console.Read();
            Console.Read();
        }       
    }
    Code Explanation:
    I created the code to implement the funny explanation provided by    
    LightStriker in the above one of the replies. We are passing 
    delegate (number)   to a method (MetYourCrush). If the Interested
    (event) occurs in the method (MetYourCrush) then it will call
    the delegate (number) which was holding the reference of
    CallMeBack method. So, the CallMeBack method will be called. 
    Basically, we are passing delegate to call the callback method. 
    Please let me know if you have any questions.
