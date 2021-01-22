    public interface ISampleInterface
    {
        // method declaration
        bool CheckSomething(object o);
    
        // event declaration
        event EventHandler ShapeChanged;
    
        // Property declaration:
        string Name
        {
            get;
            set;
        }
    }
