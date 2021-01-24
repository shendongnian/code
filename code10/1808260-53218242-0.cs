    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApp
    {
    	public partial class MainWindow : Window
    	{
    		Task _longRunningTask;
    
    		private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    		{
    			if (_longRunningTask?.IsCompleted != false)
    			{
    				return;
    			}
    
    			var canClose = false;
    
    			var dialog = new Window
    			{
    				Owner = this,
    				Width = 320,
    				Height = 200,
    				WindowStartupLocation = WindowStartupLocation.CenterOwner,
    				Content = new TextBox {
    					Text = "Please wait... ",
    					HorizontalContentAlignment = HorizontalAlignment.Center,
    					VerticalContentAlignment = VerticalAlignment.Center
    				},
    				WindowStyle = WindowStyle.None
    			};
    
    			dialog.Closing += (_, args) =>
    			{
    				args.Cancel = !canClose;
    			};
    
    			dialog.Loaded += async (_, args) =>
    			{
    				await WaitForDefferalsAsync();
    				canClose = true;
    				dialog.Close();
    			};
    
    			dialog.ShowDialog();
    		}
    
    		Task WaitForDefferalsAsync()
    		{
    			return _longRunningTask;
    		}
    
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			this.Closing += MainWindow_Closing;
    
    			_longRunningTask = Task.Delay(5000);
    		}
    	}
    }
