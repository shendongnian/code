    // not named GetThing because it doesn't return anything
    private static void Thing(Action<MyThing> thing)
    {
        using (var connection = new Connection())
        {
            thing(new MyThing(connection));
        }
    }
    
    // ...
    // you call it like this
    Thing(t=>{
      t.Read();
      t.Sing();
      t.Laugh();
    });
