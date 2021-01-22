    public class Program {
        public delegate void MyDelegate(string name);
        public event MyDelegate EventOne;
        public void HandlerOne(string name) => Console.WriteLine($"This is handler one: {name}");
        public void HandlerTwo(string name) => Console.WriteLine($"This is handler two: {name}");
        public void HandlerThree(string name) => Console.WriteLine($"This is handler three: {name}");
        public void Run() {
            EventOne += HandlerOne;
            EventOne += HandlerTwo;
            Console.WriteLine("Before clone");
            EventOne("EventOne");
            MyDelegate eventTwo = (MyDelegate)EventOne.Clone();
            MyDelegate eventTwo = EventOne;
            Console.WriteLine("After clone copy");
            EventOne("EventOne");
            eventTwo("eventTwo");
            Console.WriteLine("Change event one to show it is different");
            EventOne += HandlerThree;
            EventOne("EventOne");
            eventTwo("eventTwo");
        }
        private static void Main(string[] args) => (new Program()).Run();
    }
