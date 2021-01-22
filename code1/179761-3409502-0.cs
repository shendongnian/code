    private bool buttonResult;
    
    public void Show() {
      var control = new ControlWithSingleButton();
      bool result;
      control.damnIt_ButtonClicked += (object sender, EventArgs args) =>
      {
            this.ProcessButtonClick();
      };
      MainWindowGrid.Children.Add(control);
      MainWindowGrid.Visibility = Visibility.Visible;
      }
    private void ProcessButtonClick()
    {
       this.buttonResult = true;
       //do whatever you would have before if Show had returned true
    }
