            MouseEventArgs args = (MouseEventArgs)e;
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hit = dgv.HitTest(args.X, args.Y);
            if (hit.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                // do something here
            }
        }
