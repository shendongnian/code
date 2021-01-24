    private void btpause_click(object sender, EventArgs e)
    {
        _break = true;
    }
    // ...
    private static void Loop()
      //... Modify loop, also see first sample in the case break is set:
      Console.WriteLine(" > " + record.CustomerID + "\t" + record.Name);
      if (_break) {
          //Do staff needed at the break, like save variables
          break;
      }
      //....
