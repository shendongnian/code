                //Copyright (c) 2008 Jason Kemp
                //Permission is hereby granted, free of charge, to any person obtaining a copy
                //of this software and associated documentation files (the "Software"), to deal
                //in the Software without restriction, including without limitation the rights
                //to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                //copies of the Software, and to permit persons to whom the Software is
                //furnished to do so, subject to the following conditions:
                //The above copyright notice and this permission notice shall be included in
                //all copies or substantial portions of the Software.
                //THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                //IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                //FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                //AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                //LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                //OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
                //THE SOFTWARE.
                using System;
                using System.Runtime.InteropServices;
                using System.Windows.Forms;
                using System.Text;
                public static class Win32Utility
                {
                    [DllImport("user32.dll", CharSet = CharSet.Auto)]
                    private static extern Int32 SendMessage(IntPtr hWnd, int msg,
                        int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
                    [DllImport("user32.dll")]
                    private static extern bool SendMessage(IntPtr hwnd, int msg, int wParam, StringBuilder lParam);
                    [DllImport("user32.dll")]
                    private static extern bool GetComboBoxInfo(IntPtr hwnd, ref COMBOBOXINFO pcbi);
                    [StructLayout(LayoutKind.Sequential)]
                    private struct COMBOBOXINFO
                    {
                        public int cbSize;
                        public RECT rcItem;
                        public RECT rcButton;
                        public IntPtr stateButton;
                        public IntPtr hwndCombo;
                        public IntPtr hwndItem;
                        public IntPtr hwndList;
                    }
                    [StructLayout(LayoutKind.Sequential)]
                    private struct RECT
                    {
                        public int left;
                        public int top;
                        public int right;
                        public int bottom;
                    }
                    private const int EM_SETCUEBANNER = 0x1501;
                    private const int EM_GETCUEBANNER = 0x1502;
                    public static void SetCueText(Control control, string text)
                    {
                        if (control is ComboBox)
                        {
                            COMBOBOXINFO info = GetComboBoxInfo(control);
                            SendMessage(info.hwndItem, EM_SETCUEBANNER, 0, text);
                        }
                        else
                        {
                            SendMessage(control.Handle, EM_SETCUEBANNER, 0, text);
                        }
                    }
                    private static COMBOBOXINFO GetComboBoxInfo(Control control)
                    {
                        COMBOBOXINFO info = new COMBOBOXINFO();
                        //a combobox is made up of three controls, a button, a list and textbox;
                        //we want the textbox
                        info.cbSize = Marshal.SizeOf(info);
                        GetComboBoxInfo(control.Handle, ref info);
                        return info;
                    }
                    public static string GetCueText(Control control)
                    {
                        StringBuilder builder = new StringBuilder();
                        if (control is ComboBox)
                        {
                            COMBOBOXINFO info = new COMBOBOXINFO();
                            //a combobox is made up of two controls, a list and textbox;
                            //we want the textbox
                            info.cbSize = Marshal.SizeOf(info);
                            GetComboBoxInfo(control.Handle, ref info);
                            SendMessage(info.hwndItem, EM_GETCUEBANNER, 0, builder);
                        }
                        else
                        {
                            SendMessage(control.Handle, EM_GETCUEBANNER, 0, builder);
                        }
                        return builder.ToString();
                    }
                }
