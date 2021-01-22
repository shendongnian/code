    public class SomeClass
    {
        private int myInt;
        public event EventHandler MyIntChanging;
        public event EventHandler MyIntChanged;
        protected void OnMyIntChanging()
        {
            var handler = this.MyIntChanging;
            if (handler != null)
            {
                this.MyIntChanging(this, new EventArgs());
            }
        }
        protected void OnMyIntChanged()
        {
            var handler = this.MyIntChanged;
            if (handler != null)
            {
                this.MyIntChanged(this, new EventArgs());
            }
        }
        public int MyInt
        {
            get
            {
                return this.myInt;
            }
            set
            {
                if (this.myInt != value)
                {
                    this.OnMyIntChanging();
                    this.myInt = value;
                    this.OnMyIntChanged();
                }
            }
        }
    }
