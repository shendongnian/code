    class MainForm ... {
    
      Func<IDialogController> _controllerFactory;
    
      public MainForm(Func<IDialogController> controllerFactory) { ... }
    
      void ShowDialog() {
        using (var controller = _controllerFactory())
        {
        }
      }
