    var B = new List<B>
    {
        new B 
        { 
            Name = "One",
            A = new List<A> { new A { Id = 1 }, new A { Id = 2 }, new A { Id = 3 }
        },
        new B 
        { 
            Name = "Two",
            A = new List<A> { new A { Id = 4 }, new A { Id = 5 }, new A { Id = 6 }
        },
        new B 
        { 
            Name = "Three",
            A = new List<A> { new A { Id = 2 }, new A { Id = 2 }, new A { Id = 2 }
        },
    };
    void MyMethod(Guid id) // id  = 2
    {
        var Z = B.Where(b => b.A.Any(a => a.Id == id));
        // Output:
        //     "One"
        //     "Three"        
    }
