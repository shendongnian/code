    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyObject my = new MyObject();
                my.Changed += new EventHandler(my_Changed);
                my.Changed += new EventHandler(my_Changed1);
    
                my.Update();
                Console.ReadLine();
            }
    
            static void my_Changed(object sender, EventArgs e)
            {
                Console.WriteLine("Hello");
            }
            static void my_Changed1(object sender, EventArgs e)
            {
                Console.WriteLine("Hello1");
            }
        }
        public class MyObject
        {
            public MyObject()
            {
            }
            private EventHandler ChangedEventHandler;
            public event EventHandler Changed
            {
                add
                {
                    ChangedEventHandler = value;
                }
                remove
                {
                    ChangedEventHandler -= value;
                }
            }
            public void Update()
            {
                OnChanged();
            }
    
            private void OnChanged()
            {
                if (ChangedEventHandler != null)
                {
                    ChangedEventHandler(this, null);
                }
            }
        }
    }
