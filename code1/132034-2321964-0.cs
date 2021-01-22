    for (int i = 0; i < MySets.Count; ++i) {
       var sets = MySets[i]; // simulate `foreach` current variable
       // The rest of the code will be pretty much unchanged.
       // Now, you can set `MySets[i]` to a new object if you wish so:
       //   MySets[i] = new Settings(); 
       //
       // If you need to remove the item from a list and need to continue processing
       // the next item:   (decrementing the index var is important here)
       //   MySets.RemoveAt(i--);
       //   continue;
       
       if (sets.pName == item.SubItems[2].Text)
       {
          var ss = new SettingsForm(sets);
          if (ss.ShowDialog() == DialogResult.OK)
          {
             if (ss.ResultSave)
             {
                // Assigning to `sets` is not useful. Directly modify the list:
                MySets[i] = ss.getSettings();
             }
          }
          return;
       }
    }
