    private void GetAxisDrawLabel(object sender, GetAxisDrawLabelEventArgs e)
        {
            bool overlapPrv = false;            
            Axis axis = (Axis)sender;
            //Get the size of the label text. We have to use tcharts font, not axis font.
            SizeF currentSize = tChart1.Graphics3D.MeasureString(tChart1.Graphics3D.Font, e.Text);
            Rectangle currentRect = new Rectangle(e.X - 3, e.Y, (int)currentSize.Width + 6, (int)currentSize.Height);
            
            var index = FindLabel(tChart1.Axes.Bottom.Labels.Items, e.Text);
            //Get the AxisLabelItem we are trying to draw.
            AxisLabelItem currentLabel = axis.Labels.Items[index];
            //If we set visible to false before GetAxisDrawLabel then set e.DrawLabel to false.
            if (currentLabel.Visible == false)
            {
                _visibleLabels.Add(index, false);
                e.DrawLabel = false;
            }
            //Get the previous visible label.
            AxisLabelItem prev = null;
            var prevPair = _visibleLabels.LastOrDefault(x => x.Value == true);
            var prevIndex = -1;
            if (prevPair.Value)
            {
                prevIndex = prevPair.Key;
                tChart1.Axes.Bottom.Grid.DrawEvery = index - prevIndex;
            }
            else
            {
                //Current label is the first visible label.
                _visibleLabels.Add(index, true);
                e.DrawLabel = true;
                return;
            }
            if (prevIndex >= 0)
            {
                prev = axis.Labels.Items[prevIndex];
            }
            //If this axis is horizontal then the concern is the width of the label.
            //If there is no previous label, we draw this one.
            //TODO implementation for the vertical.
            if (axis.Horizontal == true && prev != null)
            {
                //if previous is visible we need to see if it will overlap with the current.
                if (prev.Visible == true)
                {
                    //Get the previous labels text size.
                    SizeF prevSize = tChart1.Graphics3D.MeasureString(tChart1.Graphics3D.Font, prev.Text);
                    //Get the previous label rectangle.
                    Rectangle prvRect = new Rectangle(
                       axis.CalcXPosValue(prev.Value) - 3, e.Y, (int)prevSize.Width + 6, (int)prevSize.Height);
                    //Set the overlapPrv flag by checking IntersectsWith
                    overlapPrv = currentRect.IntersectsWith(prvRect);
                }
                //if any overlap or if e.DrawLabel is false set e.DrawLabel to false.
                if (overlapPrv || e.DrawLabel == false)
                {
                    _visibleLabels.Add(index, false);
                    e.DrawLabel = false;
                }
                else
                {
                    _visibleLabels.Add(index, true);
                }
            }
        }
