    public class MyClass
    {
        private readonly Mixin1 mixin1 = new Mixin1();
        private readonly Mixin2 mixin2 = new Mixin2();
        puplic void Do1()
        {
            this.mixin1.Do1();
        }
        public void Do2()
        {
            this.mixin2.Do2();
        }
    }
