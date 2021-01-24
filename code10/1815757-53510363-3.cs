    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApp1
    {
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			var button = new Button() { Content = "Login", Width = 100, Height = 20 };
    			button.Click += HandleLogin;
    			this.Content = button;
    		}
    
    		// simulate _oidcClient.LoginAsync
    		static async Task<bool> LoginAsync(CancellationToken token)
    		{
    			await Task.Delay(5000, token);
    			return true;
    		}
    
    		void HandleLogin(object sender, RoutedEventArgs e)
    		{
    			try
    			{
    				var result = WpfTaskExt.Execute(
    					taskFunc: token => LoginAsync(token),
    					createDialog: () =>
    						new Window
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
    							WindowStyle = WindowStyle.ToolWindow
    						},
    					token: CancellationToken.None);
    
    				MessageBox.Show($"Success: {result}");
    			}
    			catch (Exception ex)
    			{
    				MessageBox.Show(ex.Message);
    			}
    		}
    	}
    
    	public static class WpfTaskExt
    	{
    		/// <summary>
    		/// Execute an async func synchronously on a UI thread,
    		/// on a modal dialog's nested message loop
    		/// </summary>
    		public static TResult Execute<TResult>(
    			Func<CancellationToken, Task<TResult>> taskFunc,
    			Func<Window> createDialog,
    			CancellationToken token = default(CancellationToken))
    		{
    			var cts = CancellationTokenSource.CreateLinkedTokenSource(token);
    
    			var dialog = createDialog();
    			var canClose = false;
    			Task<TResult> task = null;
    
    			async Task<TResult> taskRunner()
    			{
    				try
    				{
    					return await taskFunc(cts.Token);
    				}
    				finally
    				{
    					canClose = true;
    					if (dialog.IsLoaded)
    					{
    						dialog.Close();
    					}
    				}
    			}
    
    			dialog.Closing += (_, args) =>
    			{
    				if (!canClose)
    				{
    					args.Cancel = true; // must stay open for now
    					cts.Cancel();
    				}
    			};
    
    			dialog.Loaded += (_, __) =>
    			{
    				task = taskRunner();
    			};
    
    			dialog.ShowDialog();
    
    			return task.GetAwaiter().GetResult();
    		}
    	}
    }
