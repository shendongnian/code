    //this will allow you to import the necessary functions from the .dll
    using System.Runtime.InteropServices;
    
    //this imports the function used to extend the transparent window border.
    [DllImport("dwmapi.dll")]
    static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMargins);
    
    //this is used to specify the boundaries of the transparent area
    internal struct Margins {
        public int Left, Right, Top, Bottom;
    }
    private Margins marg;
    
    //Do this every time the form is resized. It causes the window to be made transparent.
    marg.Left = 0;
    marg.Top = 0;
    marg.Right = this.Width;
    marg.Bottom = this.Height;
    DwmExtendFrameIntoClientArea(this.Handle, ref marg);
    
    //This initializes the DirectX device. It needs to be done once.
    //The alpha channel in the backbuffer is critical.
    PresentParameters presentParameters = new PresentParameters();
    presentParameters.Windowed = true;
    presentParameters.SwapEffect = SwapEffect.Discard;
    presentParameters.BackBufferFormat = Format.A8R8G8B8;
    
    Device device = new Device(0, DeviceType.Hardware, this.Handle,
    CreateFlags.HardwareVertexProcessing, presentParameters);
    
    //the OnPaint functions maked the background transparent by drawing black on it.
    //For whatever reason this results in transparency.
    protected override void OnPaint(PaintEventArgs e) {
        Graphics g = e.Graphics;
    
        // black brush for Alpha transparency
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        g.FillRectangle(blackBrush, 0, 0, Width, Height);
        blackBrush.Dispose();
    
        //call your DirectX rendering function here
    }
    
    //this is the dx rendering function. The Argb clearing function is important,
    //as it makes the directx background transparent.
    protected void dxrendering() {
        device.Clear(ClearFlags.Target, Color.FromArgb(0, 0, 0, 0), 1.0f, 0);
    
        device.BeginScene();
        //draw stuff here.
        device.EndScene();
        device.Present();
    }
