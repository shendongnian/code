    string mystring = SomeObject.GetMyString();
    AnotherObject.OnSomeEvent += (eventparams => 
    {
      string newstring = string.Format(eventparams.Message, mystring);
      SomeService.PrintEvent(newstring);
    }
