    var gs = new GameString("Foo");
    gs.Append("Bar");
    gs.Append("Baz");
    gs += "Hello";
    gs += "World";
    string str = gs.ToString();
    byte[] bytes = gs.ToByteArray();
