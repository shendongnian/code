    public class Test : DependencyObject
    {
        public static DependencyProperty FooProperty = DependencyProperty.Register("Foo", typeof(string), typeof(Test));
        public string Foo
        {
            get { return (string)GetValue(FooProperty); }
            set { SetValue(FooProperty, value); }
        }
        public static DependencyProperty BarProperty = DependencyProperty.Register("Bar", typeof(int), typeof(Test));
        public int Bar
        {
            get { return (int)GetValue(BarProperty); }
            set { SetValue(BarProperty, value); }
        }
    }
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Message = "Hello";
            Answer = 42;
            var t = new Test();
            Binding fooBinding = new Binding("Message") { Source = App.Current };
            BindingOperations.SetBinding(t, Test.FooProperty, fooBinding);
            
            Binding barBinding = new Binding("Answer") { Source = App.Current };
            BindingOperations.SetBinding(t, Test.BarProperty, barBinding);
            var s = XamlWriter.Save(t);
            Debug.Print(s);
        }
        public string Message { get; set; }
        public int Answer { get; set; }
    }
