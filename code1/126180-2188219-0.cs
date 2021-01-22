    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    
    namespace ConsoleApplication1
    {
        class Foo : INotifyPropertyChanged
        {
            private object myProperty;
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(sender, e);
                }
            }
    
            public object MyProperty
            {
                get { return this.myProperty;}
                set
                {
                    if (this.myProperty != value)
                    {
                        this.myProperty = value;
                        this.OnPropertyChanged(this, new PropertyChangedEventArgs("MyPropery"));
                    }
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Foo foo = new Foo();
                foo.PropertyChanged += new PropertyChangedEventHandler(foo_PropertyChanged);
    
                foo.MyProperty = "test";
            }
    
            static void foo_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine("raised");
            }
        }
    }
