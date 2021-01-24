    // Spin up five actors, each with a unique name/reference
    // Fill in Props as needed
    var actor1 = Context.ActorOf(MyActor.Props(), "MyActor_1");
    var actor2 = Context.ActorOf(MyActor.Props(), "MyActor_2");
    var actor3 = Context.ActorOf(MyActor.Props(), "MyActor_3");
    var actor4 = Context.ActorOf(MyActor.Props(), "MyActor_4");
    var actor5 = Context.ActorOf(MyActor.Props(), "MyActor_5");
    
    // Kill the third actor by sending it a poison pill
    actor3.Tell(PoisonPill.Instance);
    
    // Send a message to any of the other actors
    actor4.Tell((long)123); // Will write 123 to the console
