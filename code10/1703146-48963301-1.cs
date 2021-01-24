c#
public sealed partial class VideoPlay : Page
{
  public VideoPlay()
  {
     this.InitializeComponent();
     //Add this line
     Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;    
  }
  void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs e)
  {
    //todo
  }
}
