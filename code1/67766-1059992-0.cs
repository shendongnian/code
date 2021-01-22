    public class MyBaseClass {
        protected virtual void OnSomethingHappend( EventArgs e ) {
            EventHandler handler = this.SomethingHappend;
            if ( null != handler ) { handler( this, e ); }
        }
        public event EventhHandler SomethingHappend;
    }
    
    public MyDerivedClass : MyBaseClass {
        public void DoSomething() {
            this.OnSomethingHappend( EventArgs.Empty );
        }
    }
