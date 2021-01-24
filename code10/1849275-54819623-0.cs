    public void gHook_KeyDown(object sender, KeyEventArgs e)
    {
        string k = e.KeyCode.ToString();
        if (KeyBindings.Contains(k)) //KeyBindings is your field or variable which is a Dictionary<string, UserAction>
        {
          var action = KeyBindings[k]
          switch (action)
          {
            case UserAction.Salvage:
              // stuff
              Salvagebtn.PerformClick();
              break;
            case UserAction.Pause:
              // stuff
              pausebtn.PerformClick();
              break;
             // and so on...
