    class Foo
    {
        public event EventHandler Did;
    
        public void Do()
        {
            Console.WriteLine("Do");
    
            this.OnDid(EventArgs.Empty);
        }
    
        protected void OnDid(EventArgs e)
        {
            var evt = this.Did;
    
            if (evt != null)
            {
                evt(this, e);
            }
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            var foo = new Foo();
    
            foo.Did += (sender, e) => Console.WriteLine("Did");
    
            foo.Do();
        }
    }
