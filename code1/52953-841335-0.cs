using System.Diagnostics;
using System.Windows.Forms;
void Init()
{
   // get handle to the main window
   intPtr mainWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
   Control mainWindow = Control.FromHandle(mainWindowHandle);
   if(mainWindow.InvokeRequired)
      mainWindow.Invoke(SetupMessageWindow);
   else
      SetupMessageWindow();
}
void SetupMessageWindow()
{
  // do your thing...
}
