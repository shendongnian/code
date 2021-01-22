    SomeDisposableObject d;
    using (var c = new AContainer()) {
       d = c.SomeObject;
    }
    // do something with d
