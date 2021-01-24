    public void Foo_TestingFoo_DoesBar()
    {
        var mockDoc = new Mock<Document>();
        var mockShape = new Mock<Shape>();
        // "implement" the methods you will need during your test
        mockDoc.Setup(...);
        mockShape.Setup(...);
        // Get the "actual" Document and Shape and use them as arguments to the ctor
        var foo = new Foo(mockDoc.Object, mockShape.Object);
        // Do stuff with foo
        foo.DoBar();
        // Verify that these objects were used how you expected them to be
        mockDoc.Verify(...);
        mockShape.Verify(...);
    }
