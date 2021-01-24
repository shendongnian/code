    #r "PresentationFramework"
    #r "Microsoft.VisualStudio.Threading"
    using System.Windows.Controls;
    using System.Windows;
    using System.Threading;
    var newWindowThread = new Thread(new ThreadStart(() =>
    {
	    var tempWindow = new Window();
    	var t = new TextBox() {Text = "test"};
	    tempWindow.Content = t;
		tempWindow.Show();
    	System.Windows.Threading.Dispatcher.Run();
    }));
    newWindowThread.SetApartmentState(ApartmentState.STA);
    newWindowThread.IsBackground = true;
    newWindowThread.Start();
