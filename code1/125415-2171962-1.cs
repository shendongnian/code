    protected ServerValidate(object sender, ServerValidateEventArgs args)
    {
      if(string.isNullOrEmpty(textbox1.Text) && string.isNullOrEmpty(textbox2.Text))
        args.IsValid = false;
      else if(!string.isNullOrEmpty(textbox1.Text) && !string.isNullOrEmpty(textbox2.Text))
        args.IsValid = false;
      else
        args.IsValid = true;
    }
    
