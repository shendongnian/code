    using System;
    using System.ComponentModel;
    using System.Reflection;
    using System.Windows.Forms;
    class MyForm : Form
    {
        public MyForm()
        { // assume we don't know this...
            Name = "My Form";
            FormClosing += Foo;
            FormClosing += Bar;
        }
    
        void Foo(object sender, FormClosingEventArgs e) { }
        void Bar(object sender, FormClosingEventArgs e) { }
    
        static void Main()
        {
            Form form = new MyForm();
            EventHandlerList events = (EventHandlerList)typeof(Component)
                .GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(form, null);
            object key = typeof(Form)
                .GetField("EVENT_FORMCLOSING", BindingFlags.NonPublic | BindingFlags.Static)
                .GetValue(null);
    
            Delegate handlers = events[key];
            foreach (Delegate handler in handlers.GetInvocationList())
            {
                MethodInfo method = handler.Method;
                string name = handler.Target == null ? "" : handler.Target.ToString();
                if (handler.Target is Control) name = ((Control)handler.Target).Name;
                Console.WriteLine(name + "; " + method.DeclaringType.Name + "." + method.Name);
            }
        }
    }
