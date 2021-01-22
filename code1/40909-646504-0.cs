			using( Mutex mutex = new Mutex( false, "mutex name" ) )
			{
				if( !mutex.WaitOne( 0, true ) )
				{
					MessageBox.Show( "Unable to run multiple instances of this program.", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error );
				}
				else
				{
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());                  
				}
			}
