    public class NavigationService
    {
       public void NavigateTo(string storyboardName)
       {
          //your logic to present storyboard
       }
    
       public void GoBack()
      {
         var poppedController = NavigationController.PopViewController(true);
         poppedController.Dispose(); //or your method where you want preclean data;
      }
    }
