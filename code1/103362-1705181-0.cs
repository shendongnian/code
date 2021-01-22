       interface ifoo
        {
            void bar();
        }
    
        class foo : ifoo
        {
            public void bar() { Console.Write("do a foo type thing"); }
        }
    
        class foo2 : ifoo
        {
            public void bar() { Console.Write("do a foo2 type thing"); }
        }
    
        class needsAnIfoo
        {
            public event EventHandler SomethingIFooCanDealWith;
            System.Threading.Timer _timer;
            public needsAnIfoo()
            {
                _timer = new System.Threading.Timer(MakeFooDoSomething, null, 0, 1000);
            }
    
            void MakeFooDoSomething(Object state)
            {
                if (SomethingIFooCanDealWith != null) 
                {
                    SomethingIFooCanDealWith(this,EventArgs.Empty);
                };
            }
        }
    
        class fooFactory
        {
            needsAnIfoo _needsAnIfoo = new needsAnIfoo();
            Dictionary<String, ifoo> _themedFoos = new Dictionary<string,ifoo>();
            ifoo _lastFoo = null;
    
            public void RegisterFoo(String themeName, ifoo foo)
            {
                _themedFoos.Add(themeName, foo);
            }
    
            public ifoo GetThemedFoo(String theme)
            {
                if (_lastFoo != null) { _needsAnIfoo.SomethingIFooCanDealWith -= (sender, e) => _lastFoo.bar(); };
                ifoo newFoo = _themedFoos[theme];
                _needsAnIfoo.SomethingIFooCanDealWith += (sender, e) => newFoo.bar();
                _lastFoo = newFoo;
                return newFoo;
            }
        }
    
        static void Main(string[] args)
        {
            fooFactory factory = new fooFactory();
            factory.RegisterFoo("CompanyA", new foo());
            factory.RegisterFoo("CompanyB", new foo2());
    
            ifoo foo = factory.GetThemedFoo("CompanyA");
            Console.Write("Press key to switch theme");
            Console.ReadKey();
    
            foo = factory.GetThemedFoo("CompanyB");
            Console.ReadKey();
        }
