    public class FlaviosAB
    {
        private AB _passThrough;
        public FlaviosAB(){
            _passThrough = new AB();
        }
    
        public void execute()
        {
            //Your code...
            Console.WriteLine("In My Execute");
            //Then call the passThrough's execute.
            _passThrough.execute();
        }
    }
