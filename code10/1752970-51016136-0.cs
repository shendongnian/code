    public class YourForm : Form
    {
        private IDictionary<Button, ListBox> _listboxes = new Dictionary<Button, ListBox>();
        // use this if you create a button and listbox simultaneously
        protected void CreateButtonAndList()
        {
            var listbox = new ListBox();
            // initialize listbox as needed
            var button = new Button();
            // initialize button as needed
            button.Click += ButtonClickHandler;
            _listboxes.Add(button, listbox);
        }
        // use this if you create a button for already existing listbox
        protected void CreateButtonFor(ListBox listbox)
        {
            var button = new Button();
            // initialize button as needed
            button.Click += ButtonClickHandler;
            _listboxes.Add(button, listbox);
        }
        private void ButtonClickHandler(object sender, EventArgs e)
        {
            var listbox = _listboxes[sender];
            // do what you want with listbox
        }
    }
