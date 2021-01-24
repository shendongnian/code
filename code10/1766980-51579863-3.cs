    void MyMethod(Guid id) // id  = 2
    {
        var Z = B.Where(b => b.A.All(a => a.Id == id));
        // Output:
        //     "Three"
    }
