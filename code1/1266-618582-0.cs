    interface IPropA 
    {
        string PropA { get; set; } 
    }
    interface IPropB 
    {
        string PropB { get; set; }
    }
    class TestClass 
    {
        void DoSomething<T>(T t) where T : IPropA, IPropB 
        {
            MessageBox.Show(t.PropA);
            MessageBox.Show(t.PropB);
        }
    }
