    interface ISpeak
    {
        void sayHello();
        void sayGoodbye();
    }
    interface IWalk
    {
        void walkForward();
        void walkBackward();
    }
    class Person : ISpeak, IWalk
    {
        void ISpeak.sayHello() { }
        void ISpeak.sayGoodbye() { }
        void IWalk.walkForward() { }
        void IWalk.walkBackward() { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            IWalk walk = person;
            ISpeak speak = person;
            speak.sayHello();
            walk.walkForward();
        }
    }
