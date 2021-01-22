    In:
            protected override void OnClick(EventArgs e)
            {
                if (SecondaryContextMenu == null || MouseButtons != MouseButtons.Right)
                {
                    base.OnClick(e);
                }
            }
