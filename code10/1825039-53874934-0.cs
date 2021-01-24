    class MyClass {
       
       private bool keySent = false;
     
       protected override void WndProc(ref Message xMessage)
       {
            if (keySent)
                return;
    
            base.WndProc(ref xMessage);
     
            if (bool value)
                 SendKeys.Send("n");
            else
                 SendKeys.SendWait("^n");
    
            keySent = true;
    
       }
    }
