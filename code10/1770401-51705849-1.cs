    private void InitializeComponent()
        {
            // 
            // button1
            // 
            // Generated button1 stuff goes here.
            // 
            // Form1
            // 
            // Generated Form1 stuff goes here
            // Call this at the end so that 
            // everything is already added to the form.
            AttachInputHandler();
        }
        #endregion
        private void AttachInputHandler()
        {
            this._inputHandler = new FormInputHandler(this);
        }
        private System.Windows.Forms.Button button1;
        private FormInputHandler _inputHandler;
  
 
    
