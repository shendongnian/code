    public class MyView : ContentView
    {
        private MyViewModel Vm { get; set; }
    
        public MyView()
        {
            this.Vm = new MyViewModel();
            this.BindingContext = this.Vm;
        }
    
        public void DoSomething()
        {
            this.Vm.Count = 42;
        }
    }
