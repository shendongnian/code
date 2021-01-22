	using System.Runtime.InteropServices;
	namespace MyConsoleApp {    
		class Program    {        
			[DllImport("user32.dll")]        
			public static extern IntPtr FindWindow(string lpClassName,
                                                   string lpWindowName);   
		 
			[DllImport("user32.dll")]       
			static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
			[STAThread()]
			static void Main(string[] args)        
			{          
				Console.Title = "MyConsoleApp";
	  
				if (args.StartWith("-w"))            
				{                   
					// hide the console window                    
					setConsoleWindowVisibility(false, Console.Title);                   
					// open your form                    
					Application.EnableVisualStyles();
	                Application.SetCompatibleTextRenderingDefault(false);                    
					Application.Run( new frmMain() );           
				}           
				// else don't do anything as the console window opens by default    
			}        
			public static void setConsoleWindowVisibility(bool visible, string title)       
			{             
				//Sometimes System.Windows.Forms.Application.ExecutablePath works  
                // for the caption depending on the system you are running under.           
				IntPtr hWnd = FindWindow(null, title); 
			 
				if (hWnd != IntPtr.Zero)            
				{               
					if (!visible)                   
						//Hide the window                    
						ShowWindow(hWnd, 0); // 0 = SW_HIDE                
					else                   
						 //Show window again                    
						ShowWindow(hWnd, 1); //1 = SW_SHOWNORMA           
				 }        
			}
		}
	}
