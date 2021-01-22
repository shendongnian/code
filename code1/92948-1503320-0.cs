    public class MyForm<T> : Form
    {
    
        public event EventHandler MyClick
        {
            add { this.theButton.Click += value; }
            remove { this.theButton.Click -= value; }
        }
    
        // ...
    }
