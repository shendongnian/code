    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
    	static class Program
    	{
    		public static Form1 F1 { get; set; }
    		public static Form2 F2 { get; set; }
    
    		/// <summary>
    		/// The main entry point for the application.
    		/// </summary>
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    
    			Form1 = new Form1();
    			Form2 = new Form2();
    
    			Application.Run(Form1);
    		}
    	}
    }
Then, from any form in your application, you'll be able to use Program.Form1 or Program.Form2 as an already instantiated reference.
