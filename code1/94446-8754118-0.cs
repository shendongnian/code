    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
            ChildForm childForm = new ChildForm();
            ChangeCaption( childForm );
            //Will display the dialog with the changed caption.
            childForm.ShowDialog();
            ChangeCaption( ref childForm );
            //Will give error as it is null
            childForm.ShowDialog();
        }
        void ChangeCaption( ChildForm formParam )
        {
            // This will change openForm’s display text
            formParam.Text = "From name has now been changed";
            // No effect on openForm
            formParam = null;                        
        }
        void ChangeCaption( ref ChildForm formParam )
        {
            // This will change openForm’s display text
            formParam.Text = "From name has now been changed";
            // This will destroy the openForm variable!
            formParam = null;                        
        }
    }
