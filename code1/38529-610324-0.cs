    class SecondForm
    {
      private FirstForm firstForm;
    
      public SecondForm()
      {
        InitializeComponent();
        this.Form_Closing += delegate { firstForm.SomeEvent -= SecondForm_SomeMethod; };
      }
    
      public SecondaryForm(FirstForm form) : this()
      {
        this.firstForm = form; // optional
        firstForm.SomeEvent += new EventHandler(SecondForm_SomeMethod);
      }
    }
