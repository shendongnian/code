    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    public class MyToolTip : ToolTip
    {
        public MyToolTip()
        {
            OwnerDraw = true;
            Draw += MyToolTip_Draw;
        }
        private void MyToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
                sf.FormatFlags = StringFormatFlags.NoWrap;
                using (Font f = new Font("Arial", 7.5F))
                {
                    SizeF s = new SizeF();
                    s = e.Graphics.MeasureString(e.ToolTipText, f);
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(225, 225, 245)), e.Bounds);
                    e.DrawBorder();
                    e.Graphics.DrawString(e.ToolTipText, f, SystemBrushes.ActiveCaptionText, e.Bounds, sf);
                }
            }
        }
    }
