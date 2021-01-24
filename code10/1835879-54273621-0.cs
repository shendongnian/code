    public bool ValidateInput(string input)
    {
      Regex Rx = new Regex(@"^[\p{L} \.'\-]{0,20}$");
      Match match = rx.Match(input);
      if(match.Success) return true;
      return false;
    }
    // To call the method.
    public void Testing(){
      string userName = "your user name";
      if(ValidateInput(userName))
        MessageBox.Show("Your username incorrect.");
      else{
        // Todo something.
      }
    }
