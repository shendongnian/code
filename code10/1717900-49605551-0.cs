    https://github.com/vignesh-nethaji/Windows-Custom-Controls/blob/master/Menporul.Windows/Menporul.Windows.Controls/Controls/MenTextBox.cs
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    
    namespace Menporul.Windows.Controls
    {
        /// <summary>
        /// Menporul TextBox
        /// </summary>
        /// <author>Vignesh Nethaji</author>
        public class MenTextBox : TextBox
        {
            /// <summary>
            /// 
            /// </summary>
            private Color _focusBorderColor = Color.Blue;
            /// <summary>
            /// 
            /// </summary>
            private Color _defaultBorderColor = Color.Gray;
            /// <summary>
            /// 
            /// </summary>
            public MenTextBox()
            {
    
    
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnSizeChanged(EventArgs e)
            {
                base.OnSizeChanged(e);
                this.Refresh();
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="hwnd"></param>
            /// <returns></returns>
            [DllImport("user32")]
            private static extern IntPtr GetWindowDC(IntPtr hwnd);
            /// <summary>
            /// 
            /// </summary>
            /// <param name="m"></param>
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == 0x85 || m.Msg == 0x000F)
                {
                    Rectangle rect = new Rectangle(0, 0, Width, Height);
                    if (this.Focused)
                    {
                        
                        var dc = GetWindowDC(Handle);
                        using (Graphics g = Graphics.FromHdc(dc))
                        {
                            ControlPaint.DrawBorder(g, rect,
                           _focusBorderColor, 2, ButtonBorderStyle.Solid,
                           _focusBorderColor, 2, ButtonBorderStyle.Solid,
                           _focusBorderColor, 2, ButtonBorderStyle.Solid,
                           _focusBorderColor, 2, ButtonBorderStyle.Solid);
                        }
                    }
                    else
                    {
                        
                        var dc = GetWindowDC(Handle);
                        using (Graphics g = Graphics.FromHdc(dc))
                        {
                            ControlPaint.DrawBorder(g, rect,
                           _defaultBorderColor, 1, ButtonBorderStyle.Solid,
                           _defaultBorderColor, 1, ButtonBorderStyle.Solid,
                           _defaultBorderColor, 1, ButtonBorderStyle.Solid,
                           _defaultBorderColor, 1, ButtonBorderStyle.Solid);
                        }
                    }
                }
               
            }
        }
    }
