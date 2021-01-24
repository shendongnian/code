    //
            // GDI DLL IMPORT
            //
    
            [DllImport("gdi32.dll", SetLastError = true)]
            public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
    
            [DllImport("gdi32.dll", SetLastError = true)]
            public static extern bool DeleteObject(IntPtr hObject);
    
            [DllImport("gdi32.dll", SetLastError = true)]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
    
            [DllImport("gdi32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool DeleteDC(IntPtr hDC);
    
            [DllImport("gdi32.dll", SetLastError = true)]
            public static extern bool BitBlt(IntPtr hDC, int x, int y, int width, int height, IntPtr hDCSource, int sourceX, int sourceY, uint type);
    
            [DllImport("gdi32.dll", ExactSpelling = true)]
            public static extern bool FillRgn(IntPtr hdc, IntPtr hrgn, IntPtr hbr);
    
            [DllImport("gdi32.dll", ExactSpelling = true)]
            public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
    
            [DllImport("gdi32.dll", ExactSpelling = true)]
            public static extern IntPtr CreateSolidBrush(uint crColor);
    
            [DllImport("gdi32.dll", ExactSpelling = true)]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
    
            public const uint SRCCOPY = 0x00CC0020; // dest = source                   
            public const uint SRCPAINT = 0x00EE0086;    // dest = source OR dest           
            public const uint SRCAND = 0x008800C6;  // dest = source AND dest          
            public const uint SRCINVERT = 0x00660046;   // dest = source XOR dest          
            public const uint SRCERASE = 0x00440328;    // dest = source AND (NOT dest )   
            public const uint NOTSRCCOPY = 0x00330008;  // dest = (NOT source)             
            public const uint NOTSRCERASE = 0x001100A6; // dest = (NOT src) AND (NOT dest) 
            public const uint MERGECOPY = 0x00C000CA;   // dest = (source AND pattern)     
            public const uint MERGEPAINT = 0x00BB0226;  // dest = (NOT source) OR dest     
            public const uint PATCOPY = 0x00F00021; // dest = pattern                  
            public const uint PATPAINT = 0x00FB0A09;    // dest = DPSnoo                   
            public const uint PATINVERT = 0x005A0049;   // dest = pattern XOR dest         
            public const uint DSTINVERT = 0x00550009;   // dest = (NOT dest)               
            public const uint BLACKNESS = 0x00000042;   // dest = BLACK                    
            public const uint WHITENESS = 0x00FF0062;   // dest = WHITE     
    
            //
            // END DLL IMPORT
            //
    
            //GDI Graphics
            private Graphics g;
    
            //Colors
            private const int BACKGROUND_COLOR = 0xffffff;
            private const int GRAPH_COLOR_ONE = 0x00FF00;
    
            //Pointers
            IntPtr hdc;
            IntPtr srcb;
            IntPtr dchb;
            IntPtr origb;
            IntPtr src;
            IntPtr dch;
            IntPtr orig;
    
            //Brushes
            IntPtr brush_one;
            IntPtr brush_back;
    
            public Form1()
            {
                InitializeComponent();
                //Create a graphics engine from the window
                g = Graphics.FromHwnd(this.Handle);
    
                //Get the handle of the Window's graphics and then create a compatible source handle
                hdc = g.GetHdc();
                srcb = CreateCompatibleDC(hdc);
                src = CreateCompatibleDC(hdc);
    
                //Get the handle of a new compatible bitmap object and map it using the source handle to produce a handle to the actual source
                dchb = CreateCompatibleBitmap(hdc, ClientRectangle.Width, ClientRectangle.Height);
                origb = SelectObject(srcb, dchb);
                
                //Get the handle of a new compatible bitmap object and map it using the source handle to produce a handle to the actual source
                dch = CreateCompatibleBitmap(hdc, 32, 32);
                orig = SelectObject(src, dch);
    
                //Create the burshes
                brush_one = CreateSolidBrush(GRAPH_COLOR_ONE);
                brush_back = CreateSolidBrush(BACKGROUND_COLOR);
    
                //Create Image
                FillRectangle(brush_one, src, 0, 0, 32, 32);
    
                //Fill Background
                FillRectangle(brush_back, hdc, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
    
                this.Show();
                Render();
            }
    
            private void Render()
            {
                Stopwatch s = new Stopwatch();
                s.Start();
    
                int frames = 0;
    
                while(frames <= 30)
                {
                    frames++;
    
                    FillRectangle(brush_back, srcb, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
                    
                    for (int i = 0; i < 50; i++)
                        for (int j = 0; j < 50; j++)
                            BlitBitmap(i * 5, j * 5, 32, 32, srcb, src);
                    
                    BlitBitmap(0, 0, ClientRectangle.Width, ClientRectangle.Height, hdc, srcb);
                }
    
                s.Stop();
                float fps = (float)frames / ((float)s.ElapsedMilliseconds / 1000.0f);
                MessageBox.Show(Math.Round(fps, 2).ToString(), "FPS");
            }
    
            private void FillRectangle(IntPtr b, IntPtr hdc, int x, int y, int w, int h)
            {
                //Create the region
                IntPtr r = CreateRectRgn(x, y, x + w, y + h);
    
                //Fill the region using the specified brush
                FillRgn(hdc, r, b);
    
                //Delete the region object
                DeleteObject(r);
            }
    
            private void BlitBitmap(int x, int y, int w, int h, IntPtr to, IntPtr from)
            {
                //Blit the bits of the actual source object to the window, using its handle
                BitBlt(to, x, y, w, h, from, 0, 0, SRCCOPY);
            }
