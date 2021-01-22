    public class MoodyObject
    {
        protected virtual String getMood() 
        { 
            return "moody"; 
        }    
        public void queryMood() 
        { 
            Console.WriteLine("I feel " + getMood() + " today!"); 
        }
    }
    
    public class HappyObject : MoodyObject
    {
        protected override string getMood()
        {
            return "happy";
        }
    }
