    List<Keys> currentKeyStack = new List<Keys>();
    DateTime lastUpdate = DateTime.Now;
    TimeSpan lengthOfTimeForChordStroke = new TimeSpan(0,0,5);  //Whatever you want here.
    protected override bool ProcessCmdKey(Message msg, Keys keyData)
    {
         if (DateTime.Now - LastUpdate > lengthOfTimeForChordStroke)
         {
              currentKeyStack.Clear();
         }
     currentKeyStack.Add(keyData);
    
    //You now have a list of the the last group of keystrokes that you can process for each key command, for example:
    
         if (currentKeyStack.Count == 2) && (currentKeyStack[0] == (Keys.Control | Keys.M)) && (currentKeyStack[1] == (Keys.M))
         {
              MessageBox.Show("W00T!");
         }
    }
