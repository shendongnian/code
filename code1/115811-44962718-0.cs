    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    namespace RoundedRectangles
    {
    public abstract class RoundedRectangle
    {
        [Flags]
        public enum RectangleCorners
        {
            None = 0, TopLeft = 1, TopRight = 2, BottomLeft = 4, BottomRight = 8,
            All = TopLeft | TopRight | BottomLeft | BottomRight
        }
        public enum WhichHalf
        {
            TopLeft,
            BottomRight,
            Both
        }
        static void Corner(GraphicsPath path, int x1, int y1, int x2, int y2, int x3, int y3)
        {
            path.AddLine(x1, y1, x2, y2);
            path.AddLine(x2, y2, x3, y3);
        }
        
        public static GraphicsPath Create(int x, int y, int width, int height, int radius, RectangleCorners corners, WhichHalf half)
        {
            if (radius <= 0)
            {
                GraphicsPath rectp = new GraphicsPath();
                rectp.AddRectangle(new Rectangle(x, y, width, height));
                return rectp;
            }
            
            int dia = radius * 2;
            Rectangle TLarc = new Rectangle(x, y, dia, dia);
            Rectangle TRarc = new Rectangle(x + width - dia - 1, y, dia, dia);
            Rectangle BRarc = new Rectangle(x + width - dia - 1, y + height - dia - 1, dia, dia);
            Rectangle BLarc = new Rectangle(x, y + height - dia - 1, dia, dia);
            Rectangle TLsquare = new Rectangle(x, y, radius, radius);
            Rectangle TRsquare = new Rectangle(x + width - radius, y, radius, radius);
            Rectangle BRsquare = new Rectangle(x + width - radius, y + height - radius, radius, radius);
            Rectangle BLsquare = new Rectangle(x, y + height - radius, radius, radius);
            
            GraphicsPath p = new GraphicsPath();
            p.StartFigure();
            if (half == WhichHalf.Both || half == WhichHalf.TopLeft)
            {
                if (corners.HasFlag(RectangleCorners.BottomLeft))
                    p.AddArc(BLarc, 135, 45);
                else
                    p.AddLine(BLsquare.Left, BLsquare.Bottom, BLsquare.Left, BLsquare.Top);
                p.AddLine(BLsquare.Left, BLsquare.Top - 1, TLsquare.Left, TLsquare.Bottom + 1);
                if (corners.HasFlag(RectangleCorners.TopLeft))
                    p.AddArc(TLarc, 180, 90);
                else
                    Corner(p, TLsquare.Left, TLsquare.Bottom, TLsquare.Left, TLsquare.Top, TLsquare.Right, TLsquare.Top);
                p.AddLine(TLsquare.Right + 1, TLsquare.Top, TRsquare.Left - 1, TRsquare.Top);
                if (corners.HasFlag(RectangleCorners.TopRight))
                    p.AddArc(TRarc, -90, 45);
            }
            if (half == WhichHalf.Both || half == WhichHalf.BottomRight)
            {
                if (corners.HasFlag(RectangleCorners.TopRight))
                    p.AddArc(TRarc, -45, 45);
                else
                    p.AddLine(TRsquare.Right, TRsquare.Top, TRsquare.Right, TRsquare.Bottom);
                p.AddLine(TRsquare.Right, TRsquare.Bottom + 1, BRsquare.Right, BRsquare.Top - 1);
                if (corners.HasFlag(RectangleCorners.BottomRight))
                    p.AddArc(BRarc, 0, 90);
                else
                    Corner(p, BRsquare.Right, BRsquare.Top, BRsquare.Right, BRsquare.Bottom, BRsquare.Left, BRsquare.Bottom);
                p.AddLine(BRsquare.Left - 1, BRsquare.Bottom, BLsquare.Right + 1, BLsquare.Bottom);
                if (corners.HasFlag(RectangleCorners.BottomLeft))
                    p.AddArc(BLarc, 90, 45);
                else
                    p.AddLine(BLsquare.Right, BLsquare.Bottom, BLsquare.Left, BLsquare.Bottom);
            }
            return p;
        }
        
        public static GraphicsPath Create(Rectangle rect, int radius, RectangleCorners c, WhichHalf which_half)
        { return Create(rect.X, rect.Y, rect.Width, rect.Height, radius, c, which_half); }
        public static GraphicsPath Create(Rectangle rect, int radius, RectangleCorners c)
        { return Create(rect.X, rect.Y, rect.Width, rect.Height, radius, c, WhichHalf.Both); }
        
        public static GraphicsPath Create(Rectangle rect, int radius)
        { return Create(rect.X, rect.Y, rect.Width, rect.Height, radius, RectangleCorners.All, WhichHalf.Both); }
    }
}
