    using System;
    using System.Windows.Forms;
    
    namespace MinimizeAll
    {
    	public partial class Form1 : Form
    	{
    		private const int WmSize = 5;
    		private const int SizeRestored = 0;
    		private const int SizeMinimized = 1;
    		private const int SizeMaximized = 2;
    		private const int SizeShow = 3;
    		private const int SizeHide = 4;
    
    		public Form1()
    		{
    			InitializeComponent();
    		}
    
    		protected override void WndProc(ref Message m)
    		{
    			try
    			{
    				if (m.Msg == WmSize)
    				{
    					var wparam = m.WParam.ToInt32();
    
    					switch (wparam)
    					{
    						case SizeRestored:
    						case SizeMinimized:
    						case SizeMaximized:
    						case SizeShow:
    						case SizeHide:
    							var output = string.Format("{0}{1:X} {2:X} {3:X} {4:X} {5:X}", prefix, m.Msg, m.WParam.ToInt32(), m.LParam.ToInt32(), m.HWnd.ToInt32(), m.Result.ToInt32());
    							listMessages.Items.Add(output);
    							break;
    						default:
    							// this is just a demo (code police)...
    							base.WndProc(ref m);
    							return;
    					}
    				}
    				else
    				{
    					base.WndProc(ref m);
    				}
    			}
    			catch (Exception)
    			{
    				listMessages.Items.Add("err");
    				base.WndProc(ref m);
    			}
    		}
    	}
    }
