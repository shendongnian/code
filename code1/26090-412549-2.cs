    public class MyClass
    {
        private readonly Mixin1 mixin1 = new Mixin1();
        private readonly Mixin2 mixin2 = new Mixin2();
        public int Property1
        {
            get { return this.mixin1.Property1; }
            set { this.mixin1.Property1 = value; }
        }
        public void Do1()
        {
            this.mixin2.Do2();
        }
    }
