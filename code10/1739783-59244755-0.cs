    enter code here using System;
    enter code here using System.Threading.Tasks;
    enter code here using Windows.UI.Xaml;
    enter code here using Windows.UI.Xaml.Controls;
    enter code here namespace DuckTracker
    enter code here {
    enter code here public sealed partial class MainPage : Page
    enter code here {
    enter code here        public MainPage()
    enter code here      {
    enter code here        this.InitializeComponent();
    enter code here      }
    enter code here private async void Button_Click(object sender,RoutedEventArgs e)
    enter code here   {
    enter code here      bool canLogin = await CanLogin();
    enter code here      if (canLogin == false)
    enter code here     {
    enter code here         try
    enter code here         {
    enter code here  await AlertWithMessages("Fail", "Could not log in!", "ok");
    enter code here      }
    enter code here       catch (Exception ex)
    enter code here      {
    enter code here 
    enter code here          var dialog = new Windows.UI.Popups.MessageDialog(ex.Message, "Error");
    enter code here         await dialog.ShowAsync();
    enter code here       }
    enter code here    }
    enter code here   }
    enter code here  public async Task AlertWithMessages(string title, string msg, string confirm)
    enter code here {
    enter code here    ContentDialog dialog = new ContentDialog
    enter code here    {
    enter code here   Title = title,
    enter code here   Content = msg,
    enter code here   PrimaryButtonText = confirm
    enter code here     };
    enter code here   if (dialog.IsLoaded == false)
    enter code here    {
    enter code here       ContentDialogResult result = await dialog.ShowAsync();
    enter code here    }
           
    enter code here     }
    enter code here    public async Task<bool> CanLogin()
    enter code here    {
    enter code here       await Task.Delay(1000);
    enter code here       return false;
    enter code here     }
    enter code here   }
    enter code here }
