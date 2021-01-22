    namespace ConsoleApplication1
    {
        using System;
        using System.ComponentModel;
        using System.Linq;
        class Test : INotifyPropertyChanged
        {
            private string prop2;
            private string prop;
            public string Prop
            {
                get {
                    return prop;
                }
                set
                {
                    if (prop != value)
                    {
                        prop = value;
                        if (PropertyChanged!=null)
                            PropertyChanged(this, new PropertyChangedEventArgs("Prop"));
                    }
                }
            }
            public string Prop2
            {
                get
                {
                    return prop2;
                }
                set
                {
                    if (prop2 != value)
                    {
                        prop2 = value;
                        if (PropertyChanged != null)
                            PropertyChanged(this, new PropertyChangedEventArgs("Prop2"));
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
        class Program
        {
            static void HandleOneShot<TEventArgs>(object target, string eventName, Action<TEventArgs> action)  where TEventArgs : EventArgs
            {
                var obsEvent = Observable.FromEvent<TEventArgs>(target, eventName).Take(1);
                obsEvent.Subscribe(a => action(a.EventArgs));
            }
            static void Main(string[] args)
            {
                Test test = new Test();
                Console.WriteLine("Setup...");
                HandleOneShot<PropertyChangedEventArgs>(
                    test, 
                    "PropertyChanged", 
                    e =>
                        {
                            Console.WriteLine(" **** {0} Changed! {1}/{2}!", e.PropertyName, test.Prop, test.Prop2);
                        });
                Console.WriteLine("Setting first property...");
                test.Prop2 = "new value";
                Console.WriteLine("Setting second property...");
                test.Prop = "second value";
                Console.WriteLine("Setting first property again...");
                test.Prop2 = "other value";
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }
        }
    }
