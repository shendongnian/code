     System.Windows.Forms.Timer Timer = new System.Windows.Forms.Timer() { Interval = 30000 };
     Timer.Tick += (obj, arg) =>
     {
         check_for_changes("TEXTURE_MAX_LOAD =");
     };
     Timer.Start();
