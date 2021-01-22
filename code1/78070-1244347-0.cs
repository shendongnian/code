	#region TakeSnap Class
		IntPtr memDc;
		[StructLayout(LayoutKind.Sequential)]
			public struct Sizes
		{
			public Int32 cx;
			public Int32 cy;
			public Sizes(Int32 x, Int32 y)
			{
				cx = x;
				cy = y;
			}
		}
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct BLENDFUNCTION
		{
			public byte BlendOp;
			public byte BlendFlags;
			public byte SourceConstantAlpha;
			public byte AlphaFormat;
		}
		[StructLayout(LayoutKind.Sequential)]
			public struct Points
		{
			public Int32 x;
			public Int32 y;
			public Points(Int32 x, Int32 y)
			{
				this.x = x;
				this.y = y;
			}
		}
		[DllImport("gdi32.dll",EntryPoint="DeleteDC")]
		public static extern IntPtr DeleteDC(IntPtr hDc);
		[DllImport("gdi32.dll",EntryPoint="DeleteObject")]
		public static extern IntPtr DeleteObject(IntPtr hDc);
		[DllImport("gdi32.dll",EntryPoint="BitBlt")]
		public static extern bool BitBlt(IntPtr hdcDest,int xDest,
			int yDest,int wDest,int hDest,IntPtr hdcSource,
			int xSrc,int ySrc,int RasterOp);
		[DllImport ("gdi32.dll",EntryPoint="CreateCompatibleBitmap")]
		public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc,
			int nWidth, int nHeight);
		[DllImport ("gdi32.dll",EntryPoint="CreateCompatibleDC")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
		[DllImport ("gdi32.dll",EntryPoint="SelectObject")]
		public static extern IntPtr SelectObject(IntPtr hdc,IntPtr bmp);
		[DllImport("user32.dll", EntryPoint="GetDesktopWindow")]
		public static extern IntPtr GetDesktopWindow();
		[DllImport("user32.dll",EntryPoint="GetDC")]
		public static extern IntPtr GetDC(IntPtr ptr);
		[DllImport("user32.dll",EntryPoint="GetSystemMetrics")]
		public static extern int GetSystemMetrics(int abc);
		[DllImport("user32.dll",EntryPoint="GetWindowDC")]
		public static extern IntPtr GetWindowDC(Int32 ptr);
		[DllImport("user32.dll",EntryPoint="ReleaseDC")]
		public static extern IntPtr ReleaseDC(IntPtr hWnd,IntPtr hDc);
		protected static IntPtr m_HBitmap;
		public const int SM_CXSCREEN=0;
		public const int SM_CYSCREEN=1;
		public const int SRCCOPY = 13369376;
		#endregion
      private IntPtr get_pointer(string path)
		{
			
			Bitmap bitmap=new Bitmap(path);
			IntPtr oldBits = IntPtr.Zero;
			IntPtr screenDC = GetDC(IntPtr.Zero);
			IntPtr hBitmap = IntPtr.Zero;
			memDc = CreateCompatibleDC(screenDC);
			try
			{
				Point topLoc = new Point(Left, Top);
				Sizes bitMapSize = new Sizes(bitmap.Width, bitmap.Height);
				BLENDFUNCTION blendFunc = new BLENDFUNCTION();
				Points srcLoc = new Points(0, 0);
				hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
				IntPtr pt= SelectObject(memDc, hBitmap);
				ReleaseDC(IntPtr.Zero, screenDC);				
				return memDc;
			}
			catch(Exception ex)
			{
				return this.Handle;
			}
		}		
		public  Bitmap GetDesktopImage()
		{
			try
			{				
			
				Sizes size;	
				IntPtr hBitmap;			
				IntPtr  hDC = get_pointer(@"C:\Documents and Settings\admin\Desktop\11_13_40_453.jpg");				
				IntPtr hMemDC = CreateCompatibleDC(hDC);
				IntPtr  hDC1 = get_pointer(@"C:\Documents and Settings\admin\Desktop\11_13_42_906.jpg");		
				size.cx = this.Width-2;
				size.cy = this.Height-22;
				hBitmap = CreateCompatibleBitmap(hDC, size.cx*2, size.cy);			
				if (hBitmap!=IntPtr.Zero)
				{
					IntPtr hOld = (IntPtr)SelectObject(hMemDC, hBitmap);					
					BitBlt(hMemDC, 0, 0,size.cx,size.cy, hDC,0, 0,SRCCOPY);	
					BitBlt(hMemDC, size.cx, 0,size.cx,size.cy, hDC1,0, 0,SRCCOPY);
					SelectObject(hMemDC, hOld);							
					DeleteDC(hMemDC);					
					DeleteDC(memDc);					
					ReleaseDC(this.Handle, hDC);
					ReleaseDC(this.Handle, hDC1);				
					Bitmap bmp = System.Drawing.Image.FromHbitmap(hBitmap); 				
					DeleteObject(hBitmap);				
					GC.Collect();				
					return bmp;
				}			
				return null;
			
			}
			catch(Exception ex)
			{			
				return null;
			}
		}
		
		private void Createimage()
		{
			try
			{
				Bitmap bm= GetDesktopImage();
				bm.Save(Application.StartupPath+"\\temp\\"+DateTime.Now.ToString("hh-mm-ss ff")+".Jpeg",System.Drawing.Imaging.ImageFormat.Jpeg);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
