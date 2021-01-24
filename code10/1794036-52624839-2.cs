    public partial class YourForm
    {
        public YourForm()
        {
            InitializeComponents();
            this.Tag = Settings.MaxIdOfOpenedForm() + 1; //We are setting Tag of newly opened form
            Settings.OpenedForms.Add(this); //Adding new form to opened forms.
        }
    }
