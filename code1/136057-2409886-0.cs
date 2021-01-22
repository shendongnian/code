 	   public void DrawBreakpoint(Graphics g, int y, bool isEnabled, bool isHealthy)
		{
			int diameter = Math.Min(iconBarWidth - 2, textArea.TextView.FontHeight);
			Rectangle rect = new Rectangle(1,
			                               y + (textArea.TextView.FontHeight -
                                                               diameter) / 2,
			                               diameter,
			                               diameter);
			
			
			using (GraphicsPath path = new GraphicsPath()) {
				path.AddEllipse(rect);
				using (PathGradientBrush pthGrBrush = new PathGradientBrush(path)) {
					pthGrBrush.CenterPoint = new PointF(rect.Left + rect.Width / 3 , 
                                                rect.Top + rect.Height / 3);
					pthGrBrush.CenterColor = Color.MistyRose;
					Color[] colors = {isHealthy ? Color.Firebrick : Color.Olive};
					pthGrBrush.SurroundColors = colors;
					
					if (isEnabled) {
						g.FillEllipse(pthGrBrush, rect);
					} else {
						g.FillEllipse(SystemBrushes.Control, rect);
						using (Pen pen = new Pen(pthGrBrush)) {
							g.DrawEllipse(pen, new Rectangle(rect.X + 1, rect.Y + 1, 
                                                             rect.Width - 2, 
                                                             rect.Height - 2));
						}
					}
				}
			}
		}
