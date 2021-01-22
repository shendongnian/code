    private void buttonTestScreenCapture_Click(object sender, EventArgs e)
    {
    	try
    	{
    		BitmapSource bms = CopyScreen();
    		BitmapFrame bmf = BitmapFrame.Create(bms);
    
    		PngBitmapEncoder encoder = new PngBitmapEncoder();
    		encoder.Frames.Add(bmf);
    
    		string filepath = @"e:\(test)\test.png";
    		using (Stream stm = File.Create(filepath))
    		{
    			encoder.Save(stm);
    		}
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show($"Err={ex}");
    	}
    }
        
    public class SafeHBitmapHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern int DeleteObject(IntPtr hObject);
    
        [SecurityCritical]
        public SafeHBitmapHandle(IntPtr preexistingHandle, bool ownsHandle)
            : base(ownsHandle)
        {
            SetHandle(preexistingHandle);
        }
    
        protected override bool ReleaseHandle()
        {
            return DeleteObject(handle) > 0;
        }
    }
