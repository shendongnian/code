    public class Program
    {
        public static void Main(string[] args)
        {
            MyClassWithEvents obj = new MyClassWithEvents();
    
            obj.MyEvent += obj_myEvent;
        }
    
        private static void obj_myEvent(object sender, EventArgs e)
        {
            //Code called when my event is dispatched.
        }
    }
