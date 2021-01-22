    public void Hello(string name)
    {
      Action action = () => Console.WriteLine("Hello " + name);
      action(); // will call the above lambda !
    }
