            protected override void OnLayout(bool changed, int l, int t, int r, int b)
            {
                try
                {
                    base.OnLayout(changed, l, t, r, b);
                    if (!changed)
                        return;
                    int msw = 50;
                    int msh = 50;
                    int layoutWidth = r - l;
                    int layoutHeight = b - t;
                    msw = MeasureSpec.MakeMeasureSpec(layoutWidth, MeasureSpecMode.Exactly);
                    msh = MeasureSpec.MakeMeasureSpec(layoutHeight, MeasureSpecMode.Exactly);
                    view.Measure(msw, msh);
                    view.Layout(0, 0, layoutWidth, layoutHeight);
                }
                catch (System.Exception ex)
                {
                   Logger.WriteException(ex);
                }
                
          }
