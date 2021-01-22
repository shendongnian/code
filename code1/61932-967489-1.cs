    using System.ComponentModel;
    using System.Threading;
    using System.Windows;
    
    namespace WPFCheckBoxClickTester
    {
    	/// <summary>
    	/// Interaction logic for Window1.xaml
    	/// </summary>
    	public partial class Window1 : Window
    	{
    		private BackgroundWorker _worker = new BackgroundWorker();
    
    		public Window1()
    		{
    			InitializeComponent();
    
    			foo.IsThreeState = false;
    			this._worker.DoWork += new DoWorkEventHandler(_worker_DoWork);
    			this._worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_worker_RunWorkerCompleted);
    		}
    
    		private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    		{
    			foo.IsChecked = true;
    			foo.IsEnabled = true;
    			return;
    		}
    
    		private void _worker_DoWork(object sender, DoWorkEventArgs e)
    		{
    			Thread.Sleep(500);
    			return;
    		}
    
    		private void foo_Checked(object sender, RoutedEventArgs e)
    		{
    			if( foo.IsChecked == true && this.foo.IsEnabled )
    			{
    				this.foo.IsChecked = false;
    				this.foo.IsEnabled = false;
    
    				this._worker.RunWorkerAsync();
    			}
    			return;
    		}
    
    	}
    }
