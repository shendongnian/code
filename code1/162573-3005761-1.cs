    public class FormProvider
    {
       public static MainMenuForm MainMenu
       {
           get
           {
              if (_mainMenu == null)
              {
                _mainMenu = new MainMenuForm();
              }
              return _mainMenu;
           }
       }
       private static MainMenuForm _mainMenu;
    }
