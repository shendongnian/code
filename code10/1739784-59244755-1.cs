    using System;
    using System.Threading.Tasks;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    
    
    
    
    namespace DuckTracker
    {
    
    public sealed partial class MainPage : Page
    {
    public MainPage()
    {
    this.InitializeComponent();
    }
    
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
    bool canLogin = await CanLogin();
    
    if (canLogin == false)
    {
    try
    {
    await AlertWithMessages("Fail", "Could not log in!", "ok");
    
    }
    catch (Exception ex)
    {
    
    var dialog = new Windows.UI.Popups.MessageDialog(ex.Message, "Error");
    await dialog.ShowAsync();
    }
    
    }
    }
    
    public async Task AlertWithMessages(string title, string msg, string confirm)
    {
    ContentDialog dialog = new ContentDialog
    {
    Title = title,
    Content = msg,
    PrimaryButtonText = confirm
    };
    
    if (dialog.IsLoaded == false)
    {
    ContentDialogResult result = await dialog.ShowAsync();
    }
    
    }
    
    public async Task<bool> CanLogin()
    {
    await Task.Delay(1000);
    
    return false;
    }
    }
    }
 
