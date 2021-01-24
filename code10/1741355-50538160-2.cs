    public partial class FormName : Form
    {
        //To keep track of the previously selected control (i.e. to be deleted)
        private Control previousSelection { get; set; }
        //To keep track of whether "Garbage Mode" is enabled or disabled
        private bool IsGarbageModeEnabled { get; set; }
        //Constructor
        public FormName()
        {
            InitializeComponent();
            IsGarbageModeEnabled = false;
            previousSelection = new Control();
            //Attach a generic click handling event to each control to 
            //update "previousSelection" with each click.
            //Similar logic can be used for other events as well 
            //(e.g. GotFocus, which might even accomodate control selection via keyboard).
            InitControlsRecursive(this.Controls);
        }
        //This attaches the GenericClickHandler(Control c) to each control on the form.
        private void InitControlsRecursive(Control.ControlCollection collection)
        {
            foreach (Control c in collection)
            {
                c.MouseClick += (sender, e) => { GenericClickHandler(c); };
                InitControlsRecursive(c.Controls);
            }
        }
        //The generic click handling event we're using to update "previousSelection".
        private void GenericClickHandler(Control c)
        {
            previousSelection = c;
        }
        //By clicking the confirm deletion / OK button, we would delete the last selected control.
        private void ConfirmDeletionBtn_Click(object sender, EventArgs e)
        {
            if(IsGarbageModeEnabled == true)
            {
                if(previousSelection != ConfirmDeletionBtn || previousSelection != ToggleGarbageModeBtn)
                {
                    this.Controls.Remove(previousSelection);
                    previousSelection.Dispose();
                }
            }
        }
        //This is used to enable/disable Garbage Mode. Controls can be deleted only once it is enabled.
        private void ToggleGarbageModeBtn_Click(object sender, EventArgs e)
        {
            IsGarbageModeEnabled = !IsGarbageModeEnabled;
        }
    }
    
