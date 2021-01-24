    class Program 
    {
        static void Main(string[] args) 
        {
            ILetter myLetter = new LoveLetter();
            myLetter.Read();
            //Output : "Love Letter Reading"
            myLetter = new LeaveApplicationLetter ();
            myLetter.Read();
            //Output : "I'm on vacation"        
    
            LoveLetter mySecondLetter = new LoveLetter();
            mySecondLetter.Read();
            //Output : "Love Letter Reading"
        }
    }
