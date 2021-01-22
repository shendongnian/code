    using System;
    using System.Runtime.InteropServices;
    
    namespace ProjectApplicationTemplate
    {
    	public partial class Win32
    	{
    		public const int WM_COPYDATA = 0x004A;
    
    		public struct CopyDataStruct : IDisposable
    		{
    			public IntPtr dwData;
    			public int cbData;
    			public IntPtr lpData;
    
    			public void Dispose()
    			{
    				if (this.lpData != IntPtr.Zero)
    				{
    					LocalFree(this.lpData);
    					this.lpData = IntPtr.Zero;
    				}
    			}
    		}
    		
    		/// <summary>
    		/// The SendMessage API
    		/// </summary>
    		/// <param name="hWnd">handle to the required window</param>
    		/// <param name="Msg">the system/Custom message to send</param>
    		/// <param name="wParam">first message parameter</param>
    		/// <param name="lParam">second message parameter</param>
    		/// <returns></returns>
    		[DllImport("user32.dll")]
    		public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref CopyDataStruct lParam);
    
    		[DllImport("kernel32.dll", SetLastError = true)]
    		public static extern IntPtr LocalAlloc(int flag, int size);
    
    		[DllImport("kernel32.dll", SetLastError = true)]
    		public static extern IntPtr LocalFree(IntPtr p);
    		
    	}
    }
