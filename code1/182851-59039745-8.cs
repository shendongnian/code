    public partial class App : Application
    {
    	// ******************************************************************
    	protected override void OnStartup(StartupEventArgs e)
    	{
    		Global.Init(Application.Current.Dispatcher);
    		AppGlobal.Init(Application.Current.Dispatcher);
