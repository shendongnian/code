    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApp1
    {
    	public partial class MainWindow : Window
    	{
    		// mock up _oidcClient.LoginAsync
    		static async Task LoginAsync(CancellationToken token)
    		{
    			await Task.Delay(5000, token);
    		}
    
    		void HandleLogin(object sender, RoutedEventArgs e)
    		{
    			var cts = new CancellationTokenSource();
    
    			var dialog = new Window
    			{
    				Owner = this,
    				Width = 320,
    				Height = 200,
    				WindowStartupLocation = WindowStartupLocation.CenterOwner,
    				Content = new TextBox
    				{
    					Text = "Loggin in, please wait... ",
    					HorizontalContentAlignment = HorizontalAlignment.Center,
    					VerticalContentAlignment = VerticalAlignment.Center
    				},
    				WindowStyle = WindowStyle.None
    			};
    
    			dialog.Closing += (_, __) => cts.Cancel();
    
    			dialog.Loaded += async (_, __) =>
    			{
    				try
    				{
    					await LoginAsync(cts.Token);
    					dialog.DialogResult = true;
    				}
    				catch (Exception ex)
    				{
    					MessageBox.Show(ex is OperationCanceledException? 
    						"Login cancelled": ex.Message);
    				}
    				if (dialog.IsLoaded)
    				{
    					dialog.Close();
    				}
    			};
    
    			if (dialog.ShowDialog() == true)
    			{
    				MessageBox.Show("Logged in!");
    			}
    		}
    
    		public MainWindow()
    		{
    			var button = new Button() { Content = "Login", Width = 100, Height = 20 };
    			button.Click += HandleLogin;
    			this.Content = button;
    		}
    	}
    }
