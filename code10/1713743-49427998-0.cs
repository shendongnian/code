    using System;
    
    public class Bob
    {
      static void Main()
      {
        var b = new Bob();
        b.showYToolStripMenuItem_Click();
        Console.WriteLine(b.ShowY);
        Console.ReadLine();
      }
      // different properties of type bool, defined in form1
      private ref bool ShowX { get { return ref _showX; } }
      private ref bool ShowY { get { return ref _showY; }  }
      private bool _showX = false;
      private bool _showY = false;
    
      // generic menu strip item bool handler
      private void HandleMenuStripItemBool(ref bool boolProp)
      {
        boolProp = true;
      }
    
      // click event of the "Show X" menu strip item, defined in form1
      private void showXToolStripMenuItem_Click()
      {
        HandleMenuStripItemBool(ref ShowX);
      }
    
      // click event of the "Show Y" menu strip item, defined in form1
      private void showYToolStripMenuItem_Click()
      {
        HandleMenuStripItemBool(ref ShowY);
      }
    }
