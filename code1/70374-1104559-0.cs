    public class ThreadSafeLabel : Label {
        public override string Text {
            get {
                return InvokeRequired ? Invoke(new Func<string>(() => base.Text)) : base.Text;
            }
            set { 
                if (InvokeRequired)
                    BeginInvoke(new Action(() => base.Text = value));
                else
                    base.Text = value;
            }
    }
