    protected override void OnKeyDown(KeyEventArgs e)
    {
         if (e.Key != System.Windows.Input.Key.Tab)
         {
              base.OnKeyDown(e); //Default behavior for all other keys
         }else{
              //Custom behavior for the tab key
         }
    }
