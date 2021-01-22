    //declare a variable to hold the CurrentCulture
    System.Globalization.CultureInfo oldCI;
    //get the old CurrenCulture and set the new, en-US
    void SetNewCurrentCulture()
    {
      oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
      System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
    }
    //reset Current Culture back to the originale
    void ResetCurrentCulture()
    {
      System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
    }
