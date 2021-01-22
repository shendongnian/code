    using System.Collections.Generic;
    using System.Windows.Controls;
    namespace TestSilverlightStuff
    {
        public partial class MainPage : UserControl
        {
            public MainPage()
            {
                InitializeComponent();
            }
        }
        public class A
        {        
            public A()
            {
                Items = new List<B>();
                Items.Add(new B() { Name = "WiredPrairie" });
                Items.Add(new B() { Name = "Microsoft" });
                Items.Add(new B() { Name = "Silverlight" });
                Items.Add(new B() { Name = ".NET" });
                Items.Add(new B() { Name = "Windows" });
                Items.Add(new B() { Name = "Overflow" });
            }
            public IList<B> Items 
            { 
                get; private set; 
            }
        }
        public class B
        {
            public string Name { get; set; }
        }
    }
