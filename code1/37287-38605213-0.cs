    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace Whatever
    {
        /// <summary>
        /// Managed equivalent of the Win32 <code>RECT</code> structure.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct LtrbRectangle
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public LtrbRectangle(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }
            public Rectangle ToRectangle()
            {
                return Rectangle.FromLTRB(Left, Top, Right, Bottom);
            }
            public static LtrbRectangle FromRectangle(Rectangle rect)
            {
                return new LtrbRectangle(rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
            }
            public override string ToString()
            {
                return "{Left=" + Left + ",Top=" + Top + ",Right=" + Right + ",Bottom=" + Bottom + "}";
            }
        }
        /// <summary>
        /// A form that "snaps" to screen edges when moving.
        /// </summary>
        public class AnchoredForm : Form
        {
            private const int WmEnterSizeMove = 0x0231;
            private const int WmMoving = 0x0216;
            private const int WmSize = 0x0005;
            private SnapLocation _snapAnchor;
            private int _dragOffsetX;
            private int _dragOffsetY;
            
            /// <summary>
            /// Flags specifying which edges to anchor the form at.
            /// </summary>
            [Flags]
            public enum SnapLocation
            {
                None = 0,
                Left = 1 << 0,
                Top = 1 << 1,
                Right = 1 << 2,
                Bottom = 1 << 3,
                All = Left | Top | Right | Bottom
            }
            /// <summary>
            /// How far from the screen edge to anchor the form.
            /// </summary>
            [Browsable(true)]
            [DefaultValue(10)]
            [Description("The distance from the screen edge to anchor the form.")]
            public virtual int AnchorDistance { get; set; } = 10;
            /// <summary>
            /// Gets or sets how close the form must be to the
            /// anchor point to snap to it. A higher value gives
            /// a more noticable "snap" effect.
            /// </summary>
            [Browsable(true)]
            [DefaultValue(20)]
            [Description("The maximum form snapping distance.")]
            public virtual int SnapDistance { get; set; } = 20;
            
            /// <summary>
            /// Re-snaps the control to its current anchor points.
            /// This can be useful for re-positioning the form after
            /// the screen resolution changes.
            /// </summary>
            public void ReSnap()
            {
                SnapTo(_snapAnchor);
            }
            /// <summary>
            /// Forces the control to snap to the specified edges.
            /// </summary>
            /// <param name="anchor">The screen edges to snap to.</param>
            public void SnapTo(SnapLocation anchor)
            {
                Screen currentScreen = Screen.FromPoint(Location);
                Rectangle workingArea = currentScreen.WorkingArea;
                if ((anchor & SnapLocation.Left) != 0)
                {
                    Left = workingArea.Left + AnchorDistance;
                }
                else if ((anchor & SnapLocation.Right) != 0)
                {
                    Left = workingArea.Right - AnchorDistance - Width;
                }
                if ((anchor & SnapLocation.Top) != 0)
                {
                    Top = workingArea.Top + AnchorDistance;
                }
                else if ((anchor & SnapLocation.Bottom) != 0)
                {
                    Top = workingArea.Bottom - AnchorDistance - Height;
                }
                _snapAnchor = anchor;
            }
            private bool InSnapRange(int a, int b)
            {
                return Math.Abs(a - b) < SnapDistance;
            }
            private SnapLocation FindSnap(ref Rectangle effectiveBounds)
            {
                Screen currentScreen = Screen.FromPoint(effectiveBounds.Location);
                Rectangle workingArea = currentScreen.WorkingArea;
                SnapLocation anchor = SnapLocation.None;
                if (InSnapRange(effectiveBounds.Left, workingArea.Left + AnchorDistance))
                {
                    effectiveBounds.X = workingArea.Left + AnchorDistance;
                    anchor |= SnapLocation.Left;
                }
                else if (InSnapRange(effectiveBounds.Right, workingArea.Right - AnchorDistance))
                {
                    effectiveBounds.X = workingArea.Right - AnchorDistance - effectiveBounds.Width;
                    anchor |= SnapLocation.Right;
                }
                if (InSnapRange(effectiveBounds.Top, workingArea.Top + AnchorDistance))
                {
                    effectiveBounds.Y = workingArea.Top + AnchorDistance;
                    anchor |= SnapLocation.Top;
                }
                else if (InSnapRange(effectiveBounds.Bottom, workingArea.Bottom - AnchorDistance))
                {
                    effectiveBounds.Y = workingArea.Bottom - AnchorDistance - effectiveBounds.Height;
                    anchor |= SnapLocation.Bottom;
                }
                return anchor;
            }
            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case WmEnterSizeMove:
                    case WmSize:
                        // Need to handle window size changed as well when
                        // un-maximizing the form by dragging the title bar.
                        _dragOffsetX = Cursor.Position.X - Left;
                        _dragOffsetY = Cursor.Position.Y - Top;
                        break;
                    case WmMoving:
                        LtrbRectangle boundsLtrb = Marshal.PtrToStructure<LtrbRectangle>(m.LParam);
                        Rectangle bounds = boundsLtrb.ToRectangle();
                        // This is where the window _would_ be located if snapping
                        // had not occurred. This prevents the cursor from sliding
                        // off the title bar if the snap distance is too large.
                        Rectangle effectiveBounds = new Rectangle(
                            Cursor.Position.X - _dragOffsetX,
                            Cursor.Position.Y - _dragOffsetY,
                            bounds.Width,
                            bounds.Height);
                        _snapAnchor = FindSnap(ref effectiveBounds);
                        LtrbRectangle newLtrb = LtrbRectangle.FromRectangle(effectiveBounds);
                        Marshal.StructureToPtr(newLtrb, m.LParam, false);
                        m.Result = new IntPtr(1);
                        break;
                }
                base.WndProc(ref m);
            }
        }
    }
