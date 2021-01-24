    FormTest objectFormTest = new FormTest();
    ControlTest objectControlTest = new ControlTest();
    objectFormTest.Controls.Add(objectControlTest);   
    bool isControlExist = IsControlTestContains();
    public bool IsControlTestContains()
    {
      bool IsControlExist = false;
      if(objectFormTest==null || objectControlTest==null)
      {
          return false;
      }
      if(objectFormTest.Controls.Contains(objectControlTest))
      {
            IsControlExist=true;
      }
      return IsControlExist;
    }
