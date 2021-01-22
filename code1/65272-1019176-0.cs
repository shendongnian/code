    class Program
    {
        static void Main()
        {
            Foo foo = new Foo();
            foo.Fooing += (object o, EventArgs e) => Console.WriteLine("Foo foo'd");
    
            foo.PleaseRaiseFoo();
        }
    }
    
    class Foo
    {
        public event EventHandler Fooing;
    
        protected void OnFooing()
        {
            if (this.Fooing != null)
                this.Fooing(null, null);
        }
    
        public void PleaseRaiseFoo()
        {
            this.OnFooing();
        }
    }
