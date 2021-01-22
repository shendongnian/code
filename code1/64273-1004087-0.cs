		protected virtual void OnDrawTreeNode(object sender, DrawTreeNodeEventArgs e)
		{
			string text = e.Node.Text;
			Rectangle itemRect = e.Bounds;
			if (e.Bounds.Height < 1 || e.Bounds.Width < 1)
				return;
			int cIndentBy	= 19;		// TODO - support Indent value
			int cMargin		= 6;		// TODO - this is a bit random, it's slaved off the Indent in some way
			int cTwoMargins	= cMargin * 2;
			int indent = (e.Node.Level * cIndentBy) + cMargin;
			int iconLeft = indent;						// Where to draw parentage lines & icon/checkbox
			int textLeft = iconLeft + 16;				// Where to draw text
			Color leftColour = e.Node.BackColor;
			Color textColour = e.Node.ForeColor;
			if (Bitfield.IsBitSet(e.State, TreeNodeStates.Grayed))
				textColour = Color.FromArgb(255,128,128,128);
			// Grad-fill the background
			Brush backBrush = new SolidBrush(leftColour);
			e.Graphics.FillRectangle(backBrush, itemRect);
			// Faint underline along the bottom of each item
			Color separatorColor = ColourUtils.Mix(leftColour, Color.FromArgb(255,0,0,0), 0.02);
			Pen separatorPen = new Pen(separatorColor);
			e.Graphics.DrawLine(separatorPen, itemRect.Left, itemRect.Bottom-1, itemRect.Right, itemRect.Bottom-1);
			// Bodged to use Button styles as Treeview styles not available on my laptop...
			if (!HideSelection)
			{
				if (Bitfield.IsBitSet(e.State, TreeNodeStates.Selected) || Bitfield.IsBitSet(e.State, TreeNodeStates.Hot))
				{
					Rectangle selRect = new Rectangle(textLeft, itemRect.Top, itemRect.Right - textLeft, itemRect.Height);
					VisualStyleRenderer renderer = new VisualStyleRenderer((ContainsFocus) ? VisualStyleElement.Button.PushButton.Hot
																						   : VisualStyleElement.Button.PushButton.Normal);
					renderer.DrawBackground(e.Graphics, selRect);
					// Bodge to make VisualStyle look like Explorer selections - overdraw with alpha'd white rectangle to fade the colour a lot
					Brush bodge = new SolidBrush(Color.FromArgb((Bitfield.IsBitSet(e.State, TreeNodeStates.Hot)) ? 224 : 128,255,255,255));
					e.Graphics.FillRectangle(bodge, selRect);
				}
			}
			Pen dotPen = new Pen(Color.FromArgb(128,128,128));
			dotPen.DashStyle = DashStyle.Dot;
			int midY = (itemRect.Top + itemRect.Bottom) / 2;
			// Draw parentage lines
			if (ShowLines)
			{
				int x	 = cMargin * 2;
				if (e.Node.Level == 0 && e.Node.PrevNode == null)
				{
					// The very first node in the tree has a half-height line
					e.Graphics.DrawLine(dotPen, x, midY, x, itemRect.Bottom);
				}
				else
				{
					TreeNode testNode = e.Node;			// Used to only draw lines to nodes with Next Siblings, as in normal TreeViews
					for (int iLine = e.Node.Level; iLine >= 0; iLine--)
					{
						if (testNode.NextNode != null)
						{
							x = (iLine * cIndentBy) + (cMargin * 2);
							e.Graphics.DrawLine(dotPen, x, itemRect.Top, x, itemRect.Bottom);
						}
						testNode = testNode.Parent;
					}
					x = (e.Node.Level * cIndentBy) + cTwoMargins;
					e.Graphics.DrawLine(dotPen,  x, itemRect.Top, x, midY);
				}
				e.Graphics.DrawLine(dotPen, iconLeft + cMargin, midY, iconLeft + cMargin + 10, midY);
			}
			// Draw Expand (plus/minus) icon if required
			if (ShowPlusMinus && e.Node.Nodes.Count > 0)
			{
				// Use the VisualStyles renderer to use the proper OS-defined glyphs
				Rectangle expandRect = new Rectangle(iconLeft-1, midY - 7, 16, 16);
				VisualStyleElement element = (e.Node.IsExpanded) ? VisualStyleElement.TreeView.Glyph.Opened
																 : VisualStyleElement.TreeView.Glyph.Closed;
				VisualStyleRenderer renderer = new VisualStyleRenderer(element);
				renderer.DrawBackground(e.Graphics, expandRect);
			}
			// Draw the text, which is separated into columns by | characters
			Point textStartPos = new Point(itemRect.Left + textLeft, itemRect.Top);
			Point textPos = new Point(textStartPos.X, textStartPos.Y);
			Font textFont = e.Node.NodeFont;	// Get the font for the item, or failing that, for this control
			if (textFont == null)
				textFont = Font;
			StringFormat drawFormat = new StringFormat();
			drawFormat.Alignment = StringAlignment.Near;
			drawFormat.LineAlignment = StringAlignment.Center;
			drawFormat.FormatFlags = StringFormatFlags.NoWrap;
			string [] columnTextList = text.Split('|');
			for (int iCol = 0; iCol < columnTextList.GetLength(0); iCol++)
			{
				Rectangle textRect = new Rectangle(textPos.X, textPos.Y, itemRect.Right - textPos.X, itemRect.Bottom - textPos.Y);
				if (mColumnImageList != null && mColumnImageList[iCol] != null)
				{
					// This column has an imagelist assigned, so we use the column text as an integer zero-based index
					// into the imagelist to indicate the icon to display
					int iImage = 0;
					try
					{
						iImage = MathUtils.Clamp(Convert.ToInt32(columnTextList[iCol]), 0, mColumnImageList[iCol].Images.Count);
					}
					catch(Exception)
					{
						iImage = 0;
					}
					e.Graphics.DrawImageUnscaled(mColumnImageList[iCol].Images[iImage], textRect.Left, textRect.Top);
				}
				else
					e.Graphics.DrawString(columnTextList[iCol], textFont, new SolidBrush(textColour), textRect, drawFormat);
				textPos.X += mColumnWidthList[iCol];
			}
			// Draw Focussing box around the text
			if (e.State == TreeNodeStates.Focused)
			{
				SizeF size = e.Graphics.MeasureString(text, textFont);
				size.Width = (ClientRectangle.Width - 2) - textStartPos.X;
				size.Height += 1;
				Rectangle rect = new Rectangle(textStartPos, size.ToSize());
				e.Graphics.DrawRectangle(dotPen, rect);
    //			ControlPaint.DrawFocusRectangle(e.Graphics, Rect);
			}
		}
