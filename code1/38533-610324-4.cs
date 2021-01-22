    class SecondForm
    {
      private FirstForm firstForm;
    
      public SecondForm()
      {
        InitializeComponent();
        // this means unregistering on form closing, uncomment if is necessary (anonymous delegate)
        //this.Form_Closing += delegate { firstForm.SomeEvent -= SecondForm_SomeMethod; };
      }
    
      public SecondaryForm(FirstForm form) : this()
      {
        this.firstForm = form; 
        firstForm.Timer.Tick += new EventHandler(Timer_Tick);
      }
      // make it public in case of external event handlers registration
      private void Timer_Tick(object sender, EventArgs e)
      {
        // now you can access firstForm or it's timer here
      }
    }
    class FirstForm
    {
      public Timer Timer
      {
        get
        {
          return this.the_timerl
        }
      }
    
      public FirstForm()
      {
        InitializeComponent();
      }
    
      private void Button_Click(object sender, EventArgs e)
      {
        new SecondForm(this).ShowDialog(); // in case of internal event handlers registration (in constructor)
        // or
        SecondForm secondForm = new SecondForm(this);
        the_timer.Tick += new EventHandler(secondForm.Timer_tick); // that method must be public
      }
