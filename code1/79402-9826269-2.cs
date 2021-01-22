    using System.Drawing;
    using System.Windows.Forms;
    public Rectangle[] FindDockedTaskBars(ref int DockedRectCounter)
    {
        int LeftDockedWidth = 0;
        int TopDockedHeight = 0;
        int RightDockedWidth = 0;
        int BottomDockedHeight = 0;
        Rectangle[] DockedRects = new Rectangle[Screen.AllScreens.Count() * 4]; 
        DockedRectCounter = 0;
        foreach (Screen TmpScrn in Screen.AllScreens)
        {
            if (!TmpScrn.Bounds.Equals(TmpScrn.WorkingArea))
            {
                LeftDockedWidth = Math.Abs(Math.Abs(TmpScrn.Bounds.Left) - Math.Abs(TmpScrn.WorkingArea.Left));
                TopDockedHeight = Math.Abs(Math.Abs(TmpScrn.Bounds.Top) - Math.Abs(TmpScrn.WorkingArea.Top));
                RightDockedWidth = (TmpScrn.Bounds.Width - LeftDockedWidth) - TmpScrn.WorkingArea.Width;
                BottomDockedHeight = (TmpScrn.Bounds.Height - TopDockedHeight) - TmpScrn.WorkingArea.Height;
                if (LeftDockedWidth > 0)
                {
                    DockedRects[DockedRectCounter].X = TmpScrn.Bounds.Left;
                    DockedRects[DockedRectCounter].Y = TmpScrn.Bounds.Top;
                    DockedRects[DockedRectCounter].Width = LeftDockedWidth;
                    DockedRects[DockedRectCounter].Height = TmpScrn.Bounds.Height;
                    DockedRectCounter += 1;
                }
                if (RightDockedWidth > 0)
                {
                    DockedRects[DockedRectCounter].X = TmpScrn.WorkingArea.Right;
                    DockedRects[DockedRectCounter].Y = TmpScrn.Bounds.Top;
                    DockedRects[DockedRectCounter].Width = RightDockedWidth;
                    DockedRects[DockedRectCounter].Height = TmpScrn.Bounds.Height;
                    DockedRectCounter += 1;
                }
                if (TopDockedHeight > 0)
                {
                    DockedRects[DockedRectCounter].X = TmpScrn.WorkingArea.Left;
                    DockedRects[DockedRectCounter].Y = TmpScrn.Bounds.Top;
                    DockedRects[DockedRectCounter].Width = TmpScrn.WorkingArea.Width;
                    DockedRects[DockedRectCounter].Height = TopDockedHeight;
                    DockedRectCounter += 1;
                }
                if (BottomDockedHeight > 0)
                {
                    DockedRects[DockedRectCounter].X = TmpScrn.WorkingArea.Left;
                    DockedRects[DockedRectCounter].Y = TmpScrn.WorkingArea.Bottom;
                    DockedRects[DockedRectCounter].Width = TmpScrn.WorkingArea.Width;
                    DockedRects[DockedRectCounter].Height = BottomDockedHeight;
                    DockedRectCounter += 1;
                }
            }
        }
        return DockedRects;
    }
