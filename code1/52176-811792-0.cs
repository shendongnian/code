    void SomeInitializationFunction() {
          button.Click += new System.EventHandler(buttonClick);
    }
    
    private void buttonClick(object sender, System.EventArgs e)
    {
        using(GetNumberForm getNumberForm = new GetNumberForm())
        {
            if(DialogResult.OK == getNumberForm.ShowDialog())
            {
                string phoneNumber = getNumberForm.PhoneNumber;
                // do something with the user input.
            }
        }
    }
