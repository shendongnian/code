    public partial class WinApi
    {
        public enum WinMessage : int
        {
            WM_DWMCOMPOSITIONCHANGED = 0x031E,          //The system will send a window the WM_DWMCOMPOSITIONCHANGED message to indicate that the availability of desktop composition has changed.
            WM_DWMNCRENDERINGCHANGED = 0x031F,          //WM_DWMNCRENDERINGCHANGED is called when the non-client area rendering status of a window has changed. Only windows that have set the flag DWM_BLURBEHIND.fTransitionOnMaximized to true will get this message.
            WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320,    //Sent to all top-level windows when the colorization color has changed.
            WM_DWMWINDOWMAXIMIZEDCHANGE = 0x0321        //WM_DWMWINDOWMAXIMIZEDCHANGE will let you know when a DWM composed window is maximized. You also have to register for this message as well. You'd have other windowd go opaque when this message is sent.
        }
        public class Dwm
            public enum DWMWINDOWATTRIBUTE : uint
            {
                NCRenderingEnabled = 1,     //Get only atttribute
                NCRenderingPolicy,          //Enable or disable non-client rendering
                TransitionsForceDisabled,
                AllowNCPaint,
                CaptionButtonBounds,
                NonClientRtlLayout,
                ForceIconicRepresentation,
                Flip3DPolicy,
                ExtendedFrameBounds,
                HasIconicBitmap,
                DisallowPeek,
                ExcludedFromPeek,
                Cloak,
                Cloaked,
                FreezeRepresentation
            }
            public enum DWMNCRENDERINGPOLICY : uint
            {
                UseWindowStyle, // Enable/disable non-client rendering based on window style
                Disabled,       // Disabled non-client rendering; window style is ignored
                Enabled,        // Enabled non-client rendering; window style is ignored
            };
            // Values designating how Flip3D treats a given window.
            enum DWMFLIP3DWINDOWPOLICY : uint
            {
                Default,        // Hide or include the window in Flip3D based on window style and visibility.
                ExcludeBelow,   // Display the window under Flip3D and disabled.
                ExcludeAbove,   // Display the window above Flip3D and enabled.
            };
            [SuppressUnmanagedCodeSecurityAttribute]
            internal static class SafeNativeMethods
            {
                //https://msdn.microsoft.com/en-us/library/windows/desktop/aa969508(v=vs.85).aspx
                [DllImport("dwmapi.dll")]
                internal static extern int DwmEnableBlurBehindWindow(IntPtr hwnd, ref DWM_BLURBEHIND blurBehind);
                //https://msdn.microsoft.com/it-it/library/windows/desktop/aa969512(v=vs.85).aspx
                [DllImport("dwmapi.dll")]
                internal static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
                //https://msdn.microsoft.com/en-us/library/windows/desktop/aa969515(v=vs.85).aspx
                [DllImport("dwmapi.dll")]
                internal static extern int DwmGetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attr, ref int attrValue, int attrSize);
                //https://msdn.microsoft.com/en-us/library/windows/desktop/aa969524(v=vs.85).aspx
                [DllImport("dwmapi.dll")]
                internal static extern int DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attr, ref int attrValue, int attrSize);
                [DllImport("dwmapi.dll")]
                internal static extern int DwmIsCompositionEnabled(ref int pfEnabled);
            }
            public static bool IsCompositionEnabled()
            {
                int pfEnabled = 0;
                int result = SafeNativeMethods.DwmIsCompositionEnabled(ref pfEnabled);
                return (pfEnabled == 1) ? true : false;
            }
            public static bool IsNonClientRenderingEnabled(IntPtr hWnd)
            {
                int gwaEnabled = 0;
                int result = SafeNativeMethods.DwmGetWindowAttribute(hWnd, DWMWINDOWATTRIBUTE.NCRenderingEnabled, ref gwaEnabled, sizeof(int));
                return (gwaEnabled == 1) ? true : false;
            }
            public static bool WindowSetAttribute(IntPtr hWnd, DWMWINDOWATTRIBUTE Attribute, int AttributeValue)
            {
                int result = SafeNativeMethods.DwmSetWindowAttribute(hWnd, Attribute, ref AttributeValue, sizeof(int));
                return (result == 0);
            }
            public static bool WindowEnableBlurBehind(IntPtr hWnd)
            {
                //Create and populate the Blur Behind structure
                DWM_BLURBEHIND Dwm_BB = new DWM_BLURBEHIND(true);
                int result = SafeNativeMethods.DwmEnableBlurBehindWindow(hWnd, ref Dwm_BB);
                return (result == 0);
            }
            public static bool WindowExtendIntoClientArea(IntPtr hWnd, WinApi.Dwm.MARGINS Margins)
            {
                // Extend frame on the bottom of client area
                int result = SafeNativeMethods.DwmExtendFrameIntoClientArea(hWnd, ref Margins);
                return (result == 0);
            }
            public static bool WindowBorderlessDropShadow(IntPtr hWnd, int ShadowSize)
            {
                MARGINS Margins = new MARGINS(0, ShadowSize, 0, ShadowSize);
                int result = SafeNativeMethods.DwmExtendFrameIntoClientArea(hWnd, ref Margins);
                return (result == 0);
            }
            public static bool WindowSheetOfGlass(IntPtr hWnd)
            {
                MARGINS Margins = new MARGINS();
                Margins.SheetOfGlass();
                //Margins set to All:-1 - Sheet Of Glass effect
                int result = SafeNativeMethods.DwmExtendFrameIntoClientArea(hWnd, ref Margins);
                return (result == 0);
            }
            public static bool WindowDisableRendering(IntPtr hWnd)
            {
                DWMNCRENDERINGPOLICY NCRP = DWMNCRENDERINGPOLICY.Disabled;
                int ncrp = (int)NCRP;
                // Disable non-client area rendering on the window.
                int result = SafeNativeMethods.DwmSetWindowAttribute(hWnd, DWMWINDOWATTRIBUTE.NCRenderingPolicy, ref ncrp, sizeof(int));
                return (result == 0);
            }
        }
    }
