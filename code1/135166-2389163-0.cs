    public static void Test()
    {
        var a = new A();
        var b = new B();
        var c = new C() {a = a, b = b};
        a.OnChange += c.Changed;
        b.OnChange += c.Changed;
        a.State = "CA";
        b.ChannelType = "TV";
    }
    class A
    {
        private string _state;
        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                if (OnChange != null) OnChange(this, EventArgs.Empty);
            }
        }
        public event EventHandler<EventArgs> OnChange;
    }
    class B
    {
        private string _channelType;
        public string ChannelType
        {
            get { return _channelType; }
            set
            {
                _channelType = value;
                if (OnChange != null) OnChange(this, EventArgs.Empty);
            }
        }
        public event EventHandler<EventArgs> OnChange;
    }
    class C
    {
        public A a { get; set; }
        public B b { get; set; }
        public void Changed(object sender, EventArgs e)
        {
            Console.WriteLine("State: {0}\tChannelType: {1}", a.State, b.ChannelType);
        }
    }
