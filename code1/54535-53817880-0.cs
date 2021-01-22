    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows;
    using System.Windows.Interop;
    using System.Xml;
    using System.Xml.Serialization;
    namespace WindowPlacementNameSpace
    {
    
        // RECT structure required by WINDOWPLACEMENT structure
        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public RECT(int left, int top, int right, int bottom)
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }
        }
        // POINT structure required by WINDOWPLACEMENT structure
        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
    
            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }
    
        // WINDOWPLACEMENT stores the position, size, and state of a window
        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public POINT minPosition;
            public POINT maxPosition;
            public RECT normalPosition;
        }
        public static class WindowPlacement
        {
            private static readonly Encoding Encoding = new UTF8Encoding();
            private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(WINDOWPLACEMENT));
            [DllImport("user32.dll")]
            private static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);
            [DllImport("user32.dll")]
            private static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);
            private const int SW_SHOWNORMAL = 1;
            private const int SW_SHOWMINIMIZED = 2;
            private static void SetPlacement(IntPtr windowHandle, string placementXml)
            {
                if (string.IsNullOrEmpty(placementXml))
                {
                    return;
                }
                byte[] xmlBytes = Encoding.GetBytes(placementXml);
                try
                {
                    WINDOWPLACEMENT placement;
                    using (MemoryStream memoryStream = new MemoryStream(xmlBytes))
                    {
                        placement = (WINDOWPLACEMENT)Serializer.Deserialize(memoryStream);
                    }
                    placement.length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
                    placement.flags = 0;
                    placement.showCmd = (placement.showCmd == SW_SHOWMINIMIZED ? SW_SHOWNORMAL : placement.showCmd);
                    SetWindowPlacement(windowHandle, ref placement);
                }
                catch (InvalidOperationException)
                {
                    // Parsing placement XML failed. Fail silently.
                }
            }
            private static string GetPlacement(IntPtr windowHandle)
            {
                WINDOWPLACEMENT placement;
                GetWindowPlacement(windowHandle, out placement);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8))
                    {
                        Serializer.Serialize(xmlTextWriter, placement);
                        byte[] xmlBytes = memoryStream.ToArray();
                        return Encoding.GetString(xmlBytes);
                    }
                }
            }
            public static void ApplyPlacement(this Window window)
            {
                var className = window.GetType().Name;
                try
                {
                    var pos = File.ReadAllText(Directory + "\\" + className + ".pos");
                    SetPlacement(new WindowInteropHelper(window).Handle, pos);
                }
                catch (Exception exception)
                {
                    Log.Error("Couldn't read position for " + className, exception);
                }
            
            }
            public static void SavePlacement(this Window window)
            {
                var className = window.GetType().Name;
                var pos =  GetPlacement(new WindowInteropHelper(window).Handle);
                try
                {
                    File.WriteAllText(Directory + "\\" + className + ".pos", pos);
                }
                catch (Exception exception)
                {
                    Log.Error("Couldn't write position for " + className, exception);
                }
            }
            private static string Directory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        }
    }
