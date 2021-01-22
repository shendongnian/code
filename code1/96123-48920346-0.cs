    // -------- IN THE MAIN FORM --------
    // CALLING THE CHILD FORM IN YOUR CODE LOOKS LIKE THIS
    Options frmOptions = new Options(UpdateSettings);
    frmOptions.Show();
     
    // YOUR FUNCTION IN THE MAIN FORM TO BE EXECUTED
    public void UpdateSettings(string data)
    {
       // DO YOUR STUFF HERE
    }
    // -------- IN THE CHILD FORM --------
 
    Action<string> UpdateSettings = null;
    
    // IN THE CHILD FORMS CONSTRUCTOR
    public Options(Action<string> UpdateSettings)
    {
        InitializeComponent();
        this.UpdateSettings = UpdateSettings;
    }
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        // CALLING THE CALLBACK FUNCTION
        if (UpdateSettings != null)
            UpdateSettings("some data");
    }
