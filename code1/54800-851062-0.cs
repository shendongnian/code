    class MyAddin {
    
         private Office.CommandBarButton myMenuItem;
    
         private void AddMenuItem() 
         {
             Application.ScreenUpdating = true;
             Application.MenuBars.Add("MyMenu");
             myMenuItem = Application.MenuBars["MyMenu"].Menus.Add("MyMenuItem1", null, null);
         }
    }
