      public class ApplicationLoader : ApplicationContext
    	{
    		#region main function
    
    		/// <summary>
    		/// The main entry point for the application.
    		/// </summary>
    		[STAThread]
    		static void Main() 
    		{
    			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
    			try
    			{
                   
                    //Application.EnableVisualStyles();
    				Application.Run(new ApplicationLoader());
    			}
    			catch( System.Exception exc )
    			{
    				MessageBox.Show( exc.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    			}
    		}
    
    		#endregion
    
    		public ApplicationLoader()
    		{
    			MainForm = new LoginForm();
    		}
    
    		protected override void OnMainFormClosed(object sender, EventArgs e)
    		{
    			if (sender is LoginForm)
    			{
    				//change forms
    			}
    			else
    				ExitThread();
    		}
    
    		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
    		{
                //catch exception
    			Application.Exit();
    		}
    	}
