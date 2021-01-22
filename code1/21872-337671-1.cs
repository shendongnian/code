    public abstract class MoodyObject
    {
        protected abstract String getMood();
    
        public void queryMood() 
        { 
            Console.WriteLine("I feel " + getMood() + " today!"); 
        }
    }
