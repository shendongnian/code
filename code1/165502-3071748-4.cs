    interface IUpdatable {
        void Update(object[] data);
    }
    class object1 : IUpdatable { public void Update(object data) { baz(data); } }
    class object2 : IUpdatable { public void Update(object data) { baz(data); } }
    
    void g(params IUpdatable[] args) {
        foreach (IUpdatable arg in args) {
             arg.Update(args);
        }
    }
    
