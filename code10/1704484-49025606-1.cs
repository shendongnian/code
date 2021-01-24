    public class Main
    {
        private string param;
        private List<IFoo> foos = new List<IFoo>();
    
        public Main(string param) { this.param = param; }
    
        public List<IFoo> Foos
        {
            get { return this.foos; }
        }
    
        public void AddFoo(int pnId, string pnName)
        {
            this.foos.Add(new Foo(this) { Id = pnId, Name = pnName });
        }
    
        public class Foo : IFoo
        {
            private Main moParent;
    
            public Foo() { }
    
            public Foo(Main poParent)
            {
                this.moParent = poParent;
            }
    
            public int Id { get; set; }
            public string Name { get; set; }
    
            //Implement interface explicitly
            void IFoo.Save()
            {
                if (this.moParent == null)
                    throw new InvalidOperationException("Parent not set");
    
                Console.WriteLine($"Save with Param: {this.moParent.param}, Id: {this.Id} Name: {this.Name}");
                //Save Item
            }
        }
    }
