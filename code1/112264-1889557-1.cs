    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    namespace DefinedRectangles
    {
        public class DisplayRect
        {
            public DisplayRect(Rectangle dispArea, Color dispColor, bool dashed)
            {
                m_area = dispArea;
                m_areaColor = dispColor;
                m_solidLines = !dashed;
            }
            Rectangle m_area;
            Color m_areaColor;
            bool m_solidLines;
            public Rectangle Bounds { get { return m_area; } }
            public void OnPaint(object sender, PaintEventArgs e)
            {
                if (!m_area.IntersectsWith(e.ClipRectangle)) { return; }
                Graphics g = e.Graphics;
                using (Pen p = new Pen(m_areaColor))
                {
                    if (m_solidLines)
                    {
                        p.DashStyle = DashStyle.Solid;
                    }
                    else
                    {
                        p.DashStyle = DashStyle.Dot;
                    }
                    // This could be improved to just the border lines that need to be redrawn
                    g.DrawRectangle(p, m_area);
                }
            }
            public void OnHitTest(object sender, MouseEventArgs e)
            {
                // Invalidation Rectangles don't include the outside bounds, while pen-drawn rectangles do.
                // We'll inflate the rectangle by 1 to make up for this issue so we can handle the hit region properly.
                Rectangle r = m_area;
                r.Inflate(1, 1);
                if (r.Contains(e.X, e.Y))
                {
                    m_solidLines = !m_solidLines;
                    Control C = (Control)sender;
                    C.Invalidate(r);
                }
            }
        }
    }
