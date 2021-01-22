        private void splitContainer_Paint(object sender, PaintEventArgs e)
		{
			SplitContainer s = sender as SplitContainer;
			if (s != null)
			{
				int gripLineWidth = 9;
				// Fill Splitter rectangle
				e.Graphics.FillRectangle(SystemBrushes.ControlDark, 
					s.SplitterRectangle.X, s.SplitterDistance, s.SplitterRectangle.Width, s.SplitterWidth);
				// Draw Single Line Border on Top and Bottom
				e.Graphics.DrawLine(Pens.LightSlateGray,
					s.SplitterRectangle.X, s.SplitterDistance, s.SplitterRectangle.Width, s.SplitterDistance);
				e.Graphics.DrawLine(Pens.LightSlateGray,
					s.SplitterRectangle.X, s.SplitterDistance + s.SplitterWidth - 1, s.SplitterRectangle.Width, s.SplitterDistance + s.SplitterWidth - 1);
				// Draw gripper dots in center
				e.Graphics.DrawLine(_dashedPen,
					((s.SplitterRectangle.Width / 2) - (gripLineWidth / 2)),
					s.SplitterDistance + s.SplitterWidth / 2,
					((s.SplitterRectangle.Width / 2) + (gripLineWidth / 2)),
					s.SplitterDistance + s.SplitterWidth / 2);
			}
		}
