    using System.Windows.Input;
    //Later on:
    protected override void OnKeyDown(KeyEventArgs e)
    {
         base.OnKeyDown(e);
         if (e.Key == System.Windows.Input.Key.Tab)
         {
              //Handle the tab key
         }
    }
