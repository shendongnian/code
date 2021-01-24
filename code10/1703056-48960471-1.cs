    public class B
    {
        A a; //initialized somewhere, you need an instance of `A`.
        //Specify what specific A's Hello you want.
        public void SayHello { Console.Write(a.Hello); }   
    }
