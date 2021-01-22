    public class Guage
    {
        private int myInt;
        public event EventHandler MyIntChanged;
        private void OnMyIntChanged()
        {
            var handler = this.MyIntChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
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
                    this.myInt = value;
                    this.OnMyIntChanged();
                }
            }
        }
    }
