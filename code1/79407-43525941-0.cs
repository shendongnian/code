    Screen sc = Screen.FromHandle(new WindowInteropHelper(this).Handle);
                if (sc.WorkingArea.Top > 0)
                {
                    // TASKBAR TOP
                }
                else if (sc.WorkingArea.Left != sc.Bounds.X)
                {
                    // TASKBAR LEFT
                }
                else if ((sc.Bounds.Height - sc.WorkingArea.Height) > 0)
                {
                    // TASKBAR BOTTOM
                }
                else if (sc.WorkingArea.Right != 0)
                {
                    // TASKBAR RIGHT
                }
                else
                {
                    // TASKBAR NOT FOUND
                }
