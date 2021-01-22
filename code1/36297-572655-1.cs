    class Program {
        public delegate void MyDelegate(string name);
        public event MyDelegate EventOne;
        public void HandlerOne(string name) {
            Console.WriteLine("This is handler one: {0}", name);
        }
        public void HandlerTwo(string name) {
            Console.WriteLine("This is handler two: {0}", name);
        }
        public void HandlerThree(string name) {
            Console.WriteLine("This is handler three: {0}", name);
        }
        public void Run() {
            EventOne += HandlerOne;
            EventOne += HandlerTwo;
            Console.WriteLine("Before clone");
            EventOne("EventOne");
            <strike>MyDelegate eventTwo = (MyDelegate)EventOne.Clone();</strike>
            MyDelegate eventTwo = EventOne;
            Console.WriteLine("After <strike>clone</strike>copy");
            EventOne("EventOne");
            eventTwo("eventTwo");
            Console.WriteLine("Change event one to show it is different");
            EventOne += HandlerThree;
            EventOne("EventOne");
            eventTwo("eventTwo");
        }
        static void Main(string[] args) {
            (new Program()).Run();
        }
    }
