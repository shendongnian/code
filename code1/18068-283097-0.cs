    enum LicenseLevel {
      Eval = 0,
      Pro = 1,
      Enterprise = 2
    }
    
    // later...    
        
    for(i=0; i < widgets.Count; i++) {
      if (i == 100 && CurrentUser.LicenseLevel < LicenseLevel.Enterprise)
        break;
      // do stuff
    }
