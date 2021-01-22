        List<Person> list = new List<Person>();
        Person person = new Person() { Name="Chris" };
        // your person object lives on the heap. The person variable is just
        // a pointer of that object on the heap. Note that the pointer lives
        // on the stack, and the object it points to lives on the heap.
        list.Add(person);
        // when you add your person to to the list, all it does it pass a
        // copy of the *pointer* to the list's method. List has access to this
        // object through the pointer.
        person = new Person(){ Name="Wilson the cat" };
        // new'ing up a instance of person creates another person object on
        // the heap. Note that this doesn't overwrite our original person created above,
        // because our original person sits in an entirely differently memory 
        // location.
        // We did, however overwrite our pointer variable by assigning it a new
        // location to point at. This doesn't affect the object we put into our
        // list since the list received a copy of our original pointer :)
        list.Add(person);
        Console.WriteLine(list[0].Name);
        // list[0] has a pointer to the first object we created
        Console.WriteLine(list[1].Name);
        // list[1] has a pointer to the second object we created.
        Console.ReadLine();
        // when this methods goes out of scope (i.e. when the stack frame is
        // popped), the pointers will be dropped from memory, and the objects
        // on the heap will no longer have any live references to them, so
        // they'll be eaten by the garbage collector.
