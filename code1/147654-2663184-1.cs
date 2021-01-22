    class Cody
    {
        public void Foo () 
        {
        }
    }
    
    class Bob : Cody
    {
        public new void Foo()
        {
            base.Foo(); // Cody.Foo()
            // extra stuff
        }
    }
