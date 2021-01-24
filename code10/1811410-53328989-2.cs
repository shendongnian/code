    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        Confirmation confirmationForm;
        private void btnRed_OnClick(object sender, EventArgs e)
        {
            if (confirmationForm == null)
            {
                confirmationForm = new Confirmation();
                // if you need for the current Menu form to be hidden, you would need Confirmation form to be aware of it. That way
                // you can make Menu form visible when Confirmation form is closed. You would need to write code in Form_Closed event.
                confirmationForm.Menu = this;
                // since you mentioned background color would be changed, if thats the only thing, you could directly set that property.
                confirmationForm.BackColor = Color.Red;
                // or if you have other bunch of properties that needs to be set or logic that needs to be run, 
                // you could create a method in Confirmation
                confirmationForm.SetProperties("red");
            }
            // you may want to use ShowDialog(), so that you wont have multiple instances of confirmation being created.
            confirmationForm.Show();
            // so that it appears in the front.
            confirmationForm.BringToFront();
            this.Hide();
        }
    }
