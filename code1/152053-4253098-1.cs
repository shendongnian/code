    public class Mainclass : MainView
    {
      public delegate abc RegisterPopUp(abc A);
      public RegisterPopUp POpUpEvent;
      public RelayCommand ShowCommand { private set; get; }  
      public void ShowCommand() 
      { 
        ShowCommand("Your parameter");
      } 
    }
