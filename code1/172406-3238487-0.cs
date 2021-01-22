    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace CSharpScratch
    {
    	class Program
    	{
    		private static void Main()
    		{
    			var myForm = new MyForm();
    			myForm.ShowDialog();
    		}
    	}
    
    	class MyForm : Form
    	{
    		private readonly Label _label;
    
    		public MyForm()
    		{
    			_label = new Label {Text = "Hello", Parent = this};
    			Load += FormLoaded;
    		}
    
    		public void FormLoaded(object sender, EventArgs args)
    		{
    			ThreadPool.QueueUserWorkItem(x =>
    				{
    					Thread.Sleep(5000);
    					BeginInvoke(new Action(() => _label.Text = "Goodbye"));
    				});
    		}
    	}
    }
