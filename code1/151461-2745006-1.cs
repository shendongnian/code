    // standard method calling
    DoSomething( "Johny", 5 );
    // since C# 4.0 you can used "named parameters"
    DoSomething( name: "Johny", number: 5 );
    // calling with parameter's "container"
    DoSomething( new DoSomethingParameters( "Johny",  5 ) );
    // calling with parameter's "container"
    DoSomething( new DoSomethingParameters{ Name = "Johny", Number = 5 } );
    // calling with callback for parameters initialization
    DoSomething( p => { p.Name = "Johny"; p.Number = 5; } );
    
    // overload of DoSomething method with callback, which initialize parameters
    public void DoSomething( Action<DoSomethingParameters> init ) {
        var p = new DoSomethingParameters();
        init( p );
        DoSomething( p );
    }
    // overload of DoSomething method for calling with simple parameters
    public void DoSomething( string name, int number ) {
        var p = new DoSomethingParameters( name, number );
        DoSomething( p );
    }
    // the "main executive" method which is "doing the work"
    // all posible parameters are specified as members of DoSomethingParameters object
    public void DoSomething( DoSomethingParameters p ) { /* ... */ }
    // specify all parameters for DoSomething method
    public class DoSomethingParameters {
        public string Name;
        public int Number;
    
        public DoSomethingParameters() { }
        public DoSomethingParameters( string name, int number ) {
            this.Name = name;
            this.Number = number;
        }
    }
