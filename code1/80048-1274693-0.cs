    class Foo
    {
        public event EventHandler DidSomething = delegate { };
        public void DoSomething( )
        {
            // do stuff, fire event
            OnDidSomething( EventArgs.Empty );
        }
        protected virtual void OnDidSomething( EventArgs e )
        {
            DidSomething( this, e );
        }
    }
