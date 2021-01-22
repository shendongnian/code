    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace standbyTest
    {
    	public partial class Form1 : Form
    	{
    
    		[DllImport("Kernel32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
    		protected static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE state);
    
    		[Flags]
    		public enum EXECUTION_STATE : uint
    		{
    			ES_CONTINUOUS = 0x80000000,
    			ES_DISPLAY_REQUIRED = 2,
    			ES_SYSTEM_REQUIRED = 1,
    			ES_AWAYMODE_REQUIRED = 0x00000040
    		}
    
    		public Form1()
    		{
    			if(Environment.OSVersion.Version.Major > 5)
    			{
    				// vista and above: block suspend mode
    				SetThreadExecutionState(EXECUTION_STATE.ES_AWAYMODE_REQUIRED | EXECUTION_STATE.ES_SYSTEM_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
    			}
    
    			InitializeComponent();
    
    			//MessageBox.Show(string.Format("version: {0}", Environment.OSVersion.Version.Major.ToString() ));
    
    		}
    
    		protected override void OnClosed(EventArgs e)
    		{
    			base.OnClosed(e);
    
    			if(Environment.OSVersion.Version.Major > 5)
    			{
    				// Re-allow suspend mode
    				SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
    			}
    		}
    
    
    		protected override void WndProc(ref System.Windows.Forms.Message m)
    		{
    			// Power status event triggered
    			if(m.Msg == (int)WindowMessage.WM_POWERBROADCAST)
    			{
    				// Machine is trying to enter suspended state
    				if(m.WParam.ToInt32() == (int)WindowMessage.PBT_APMQUERYSUSPEND ||
    						m.WParam.ToInt32() == (int)WindowMessage.PBT_APMQUERYSTANDBY)
    				{
    					// Have perms to deny this message?
    					if((m.LParam.ToInt32() & 0x1) != 0)
    					{
    						// If so, deny broadcast message
    						m.Result = new IntPtr((int)WindowMessage.BROADCAST_QUERY_DENY);
    					}
    				}
    				return;
    			}
    
    			base.WndProc(ref m);
    		}
    	}
    
    	
    
    	internal enum WindowMessage
    	{
    
    		/// <summary>
    		/// Notify that machine power state is changing
    		/// </summary>
    		WM_POWERBROADCAST = 0x218,
    		/// <summary>
    		/// Message indicating that machine is trying to enter suspended state
    		/// </summary>
    		PBT_APMQUERYSUSPEND = 0x0,
    		PBT_APMQUERYSTANDBY = 0x0001,
    
    		/// <summary>
    		/// Message to deny broadcast query
    		/// </summary>
    		BROADCAST_QUERY_DENY = 0x424D5144
    
    
    	}
    }
