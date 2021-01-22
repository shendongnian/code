    class Foo
    {
        public string this[int i]
        {
            get { return someData[i]; }
            set { someData i = value; }
        }
    }
    // ... later in code
  
    Foo f = new Foo( );
    string s = f[0];
