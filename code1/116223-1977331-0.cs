    static void Main(string[] args)  
    {
      using (Publisher pub = new Publisher())  
      { 
        pub.MyEvent += new EventHandler(pub_MyEvent1); 
        Console.ReadLine(); 
      }  
      using (Publisher pub = new Publisher())  
      {
        pub.MyEvent += new EventHandler(pub_MyEvent); 
        Console.ReadLine();  
      }  
    }
