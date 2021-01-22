    DoSomething( "Johny", 5 );
    DoSomething( name: "Johny", number: 5 );
    DoSomething( new DoSomethingParameters( "Johny",  5 ) );
    DoSomething( new DoSomethingParameters{ Name = "Johny", Number = 5 } );
    DoSomething( p => { p.Name = "Johny"; p.Number = 5; } );
    
    public void DoSomething( Action<DoSomethingParameters> init ) {
        var p = new DoSomethingParameters();
        init( p );
        DoSomething( p );
    }
    public void DoSomething( DoSomethingParameters p ) {
        DoSomething( p.Name, p.Number );
    }
    public void DoSomething( string name, int number ) { /* ... */ }
    public class DoSomethingParameters {
        public string Name;
        public int Number;
    
        public DoSomethingParameters() { }
        public DoSomethingParameters( string name, int number ) {
            this.Name = name;
            this.Number = number;
        }
    }
