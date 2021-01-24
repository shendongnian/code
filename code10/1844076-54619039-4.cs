    void method(class1 b)
    {
        b = new class1(); // This does NOT change a.
        // But
        b.IntProperty = 5; // This changes a property of a.
    }
