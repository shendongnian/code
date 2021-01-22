    public class Form2 : Form
    {
        public event EventHandler DbChanged;
        protected virtual void OnDbChanged()
        {
            ... // Raise event
        }
        // On OK button/FormClosing/Closed whatever, be sure to call OnDbChanging
    }
