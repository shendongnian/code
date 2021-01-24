    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Windows.Input;
    
    namespace Hector.Framework.Utils
    {
        public class Peripherals
        {
            public class Mouse
            {
                public static int X
                {
                    get => Cursor.Position.X;
                }
    
                public static int Y
                {
                    get => Cursor.Position.Y;
                }
    
                public static void MoveToPoint(int X, int Y)
                {
                    Win32.SetCursorPos(X, Y);
                }
    
                public static void Hide()
                {
                    Cursor.Hide();
                }
    
                public static void Show()
                {
                    Cursor.Show();
                }
    
                public static bool IsHidden
                {
                    get => Cursor.Current == null;
                }
    
                /// <summary>
                /// ButtonNumber: 0-None 1-Left 2-Middle 3-Right 4-XButton1 5-XButton2
                /// </summary>
                public static bool MouseButtonIsDown(int ButtonNumber)
                {
                    bool outValue = false;
                    bool isLeft = Control.MouseButtons == MouseButtons.Left;
                    bool isRight = Control.MouseButtons == MouseButtons.Right;
                    bool isMiddle = Control.MouseButtons == MouseButtons.Middle;
                    bool isXButton1 = Control.MouseButtons == MouseButtons.XButton1;
                    bool isXButton2 = Control.MouseButtons == MouseButtons.XButton2;
    
                    switch (ButtonNumber)
                    {
                        case 0:
                            outValue = false;
                            break;
                        case 1:
                            outValue = isLeft;
                            break;
                        case 2:
                            outValue = isMiddle;
                            break;
                        case 3:
                            outValue = isRight;
                            break;
                        case 4:
                            outValue = isXButton1;
                            break;
                        case 5:
                            outValue = isXButton2;
                            break;
                    }
    
                    return outValue;
                }
    
                /// <summary>
                /// This function is in Alpha Phase
                /// </summary>
                /// <param name="FocusedControl">The control that is scrolled; If the control has no focus, it will be applied automatically</param>
                /// <param name="FontSize">This is used to calculate the number of pixels to move, its default value is 20</param>
                static int delta = 0;
                static int numberOfTextLinesToMove = 0;
                static int numberOfPixelsToMove = 0;
                public static bool GetWheelValues(Control FocusedControl, out int Delta, out int NumberOfTextLinesToMove, out int NumberOfPixelsToMove, int FontSize = 20)
                {
                    try
                    {
                        if (FocusedControl == null) throw new NullReferenceException("The FocusedControl can not bel null");
                        if (!FocusedControl.Focused) FocusedControl.Focus();
                        FocusedControl.MouseWheel += (object sender, MouseEventArgs e) =>
                        {
                            delta = e.Delta;
                            numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
                            numberOfPixelsToMove = numberOfTextLinesToMove * FontSize;
                        };
    
                        Delta = delta;
                        NumberOfTextLinesToMove = numberOfTextLinesToMove;
                        NumberOfPixelsToMove = numberOfPixelsToMove;
    
                        return true;
                    }
                    catch
                    {
                        Delta = 0;
                        NumberOfTextLinesToMove = 0;
                        NumberOfPixelsToMove = numberOfPixelsToMove;
    
                        return false;
                    }
                }
    
                private class Win32
                {
                    [DllImport("User32.Dll")]
                    public static extern long SetCursorPos(int x, int y);
    
                    [DllImport("User32.Dll")]
                    public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);
    
                    [StructLayout(LayoutKind.Sequential)]
                    public struct POINT
                    {
                        public int x;
                        public int y;
                    }
                }
            }
        }
    }
