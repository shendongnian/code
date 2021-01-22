        public Form1()
        {
            Button b = new Button();
            TextBox tb = new TextBox();
            this.Controls.Add(b);
            this.Controls.Add(tb);
            WireUp(b, "Click", "Clickbutton");
            WireUp(tb, "KeyDown", "Clickbutton");
        }
        void WireUp(object o, string eventname, string methodname)
        {
            EventInfo ei = o.GetType().GetEvent(eventname);
            MethodInfo mi = this.GetType().GetMethod(methodname, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            Delegate del = Delegate.CreateDelegate(ei.EventHandlerType, this, mi);
            ei.AddEventHandler(o, del);
        }
        void Clickbutton(object sender, System.EventArgs e)
        {
            MessageBox.Show("hello!");
        }
