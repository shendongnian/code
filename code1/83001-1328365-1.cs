    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Drawing;
    using Microsoft.WindowsCE.Forms;
    
    namespace DeviceApplication1
    {
        /// <summary>
        /// Handles showing and hiding of Soft Input Panel (SIP).  Better to use these
        /// methods than having an InputControl on a form.  InputControls behave oddly
        /// if you have multiple forms open.
        /// </summary>
        public class SIPHandler
        {
            public static void ShowSIP()
            {
                SipShowIM(1);
            }
    
            public static void ShowSIPNumeric()
            {
                SipShowIM(1);
                SetKeyboardToNumeric();
            }
    
            public static void ShowSIPRegular()
            {
                SipShowIM(1);
                SetKeyboardToRegular();
            }
    
            public static void HideSIP()
            {
                SipShowIM(0);
            }
    
            private static void SetKeyboardToRegular()
            {
                // Find the SIP window
                IntPtr hWnd = FindWindow("SipWndClass", null);
                // Go one level below as the actual SIP window is a child
                hWnd = GetWindow(hWnd, GW_CHILD);
                // Obtain its context and get a color sample
                // The premise here is that the numeric mode is controlled by a virtual button in the top left corner
                // Whenever the numeric mode is active, the button background will be of COLOR_WINDOW_TEXT
                IntPtr hDC = GetDC(hWnd);
                int pixel = GetPixel(hDC, 2, 2);
                // Notice that we cannot simply compare the color to the system color as the system color is 24 bit (or palette)
                // and the real color is dithered to 15-16 bits for most devices, so white (0xff, 0xff, 0xff) becomes
                // almost white (oxf8, 0xfc, 0xf8)
                
                // ken's hack:  here we only want to simulate the click if the keyboard is in numeric mode, in 
                // which case the back color will be WindowText
                //int clrText = (SystemColors.Window.R) | (SystemColors.Window.G << 8) | (SystemColors.Window.B << 16);
                int clrText = (SystemColors.WindowText.R) | (SystemColors.WindowText.G << 8) | (SystemColors.WindowText.B << 16);
                
                SetPixel(hDC, 2, 2, clrText);
                int pixelNew = GetPixel(hDC, 2, 2);
                // Restore the original pixel
                SetPixel(hDC, 2, 2, pixel);
    
                if (pixel == pixelNew)
                {
                    // Simulate stylus click
                    Message msg = Message.Create(hWnd, WM_LBUTTONDOWN, new IntPtr(1), new IntPtr(0x00090009));
                    MessageWindow.SendMessage(ref msg);
                    msg = Message.Create(hWnd, WM_LBUTTONUP, new IntPtr(0), new IntPtr(0x00090009));
                    MessageWindow.SendMessage(ref msg);
                }
                // Free resources
                ReleaseDC(hWnd, hDC);
            }
    
            private static void SetKeyboardToNumeric()
            {
                // Find the SIP window
                IntPtr hWnd = FindWindow("SipWndClass", null);
                // Go one level below as the actual SIP window is a child
                hWnd = GetWindow(hWnd, GW_CHILD);
                // Obtain its context and get a color sample
                // The premise here is that the numeric mode is controlled by a virtual button in the top left corner
                // Whenever the numeric mode is active, the button background will be of COLOR_WINDOW_TEXT
                IntPtr hDC = GetDC(hWnd);
                int pixel = GetPixel(hDC, 2, 2);
                // Notice that we cannot simply compare the color to the system color as the system color is 24 bit (or palette)
                // and the real color is dithered to 15-16 bits for most devices, so white (0xff, 0xff, 0xff) becomes
                // almost white (oxf8, 0xfc, 0xf8)
                int clrText = (SystemColors.Window.R) | (SystemColors.Window.G << 8) | (SystemColors.Window.B << 16);
                SetPixel(hDC, 2, 2, clrText);
                int pixelNew = GetPixel(hDC, 2, 2);
                // Restore the original pixel
                SetPixel(hDC, 2, 2, pixel);
    
                if (pixel == pixelNew)
                {
                    // Simulate stylus click
                    Message msg = Message.Create(hWnd, WM_LBUTTONDOWN, new IntPtr(1), new IntPtr(0x00090009));
                    MessageWindow.SendMessage(ref msg);
                    msg = Message.Create(hWnd, WM_LBUTTONUP, new IntPtr(0), new IntPtr(0x00090009));
                    MessageWindow.SendMessage(ref msg);
                }
                // Free resources
                ReleaseDC(hWnd, hDC);
            }
    
            [DllImport("coredll.dll")]
            private extern static bool SipShowIM(int dwFlag);
    
            [DllImport("coredll.dll")]
            private extern static IntPtr FindWindow(string wndClass, string caption);
    
            [DllImport("coredll.dll")]
            private extern static IntPtr GetWindow(IntPtr hWnd, int nType);
    
            [DllImport("coredll.dll")]
            private extern static int GetPixel(IntPtr hdc, int nXPos, int nYPos);
    
            [DllImport("coredll.dll")]
            private extern static void SetPixel(IntPtr hdc, int nXPos, int nYPos, int clr);
    
            [DllImport("coredll.dll")]
            private extern static IntPtr GetDC(IntPtr hWnd);
    
            [DllImport("coredll.dll")]
            private extern static void ReleaseDC(IntPtr hWnd, IntPtr hDC);
    
            [DllImport("coredll.dll")]
            private static extern bool SipSetCurrentIM(byte[] clsid);
    
            const int WM_LBUTTONDOWN = 0x0201;
            const int WM_LBUTTONUP = 0x0202;
            const int GW_CHILD = 5;
    
        }
    }
