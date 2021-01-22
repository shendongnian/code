      using System;
    public class Publisher //main publisher class which will invoke methods of all subscriber classes
    {
        public delegate void TickHandler(Publisher m, EventArgs e); //declaring a delegate
        public TickHandler Tick;     //creating an object of delegate
        public EventArgs e = null;   //set 2nd paramter empty
        public void Start()     //starting point of thread
        {
            while (true)
            {
                System.Threading.Thread.Sleep(300);
                if (Tick != null)   //check if delegate object points to any listener classes method
                {
                    Tick(this, e);  //if it points i.e. not null then invoke that method!
                }
            }
        }
    }
    public class Subscriber1                //1st subscriber class
    {
        public void Subscribe(Publisher m)  //get the object of pubisher class
        {
            m.Tick += HeardIt;              //attach listener class method to publisher class delegate object
        }
        private void HeardIt(Publisher m, EventArgs e)   //subscriber class method
        {
            System.Console.WriteLine("Heard It by Listener");
        }
    }
    public class Subscriber2                   //2nd subscriber class
    {
        public void Subscribe2(Publisher m)    //get the object of pubisher class
        {
            m.Tick += HeardIt;               //attach listener class method to publisher class delegate object
        }
        private void HeardIt(Publisher m, EventArgs e)   //subscriber class method
        {
            System.Console.WriteLine("Heard It by Listener2");
        }
    }
    class Test
    {
        static void Main()
        {
            Publisher m = new Publisher();      //create an object of publisher class which will later be passed on subscriber classes
            Subscriber1 l = new Subscriber1();  //create object of 1st subscriber class
            Subscriber2 l2 = new Subscriber2(); //create object of 2nd subscriber class
            l.Subscribe(m);     //we pass object of publisher class to access delegate of publisher class
            l2.Subscribe2(m);   //we pass object of publisher class to access delegate of publisher class
            m.Start();          //starting point of publisher class
        }
    }
