            #region Lambda
            item.MouseDown += new MouseEventHandler((a, b) =>
            {
                MessageBase hovering = this.GetChildAtPoint(tr_MouseCurrentPoint) as MessageBase;
                if (b.Button == MouseButtons.Left)
                {
                    tr_MouseDown = true;
                    tr_MouseDownPoint = this.PointToClient(b.Location);
                    mouseupdate();
                    foreach (var t in tr_CurrentlySelected)
                    {
                        t.Key.Selected = false;
                    }
                    tr_CurrentlySelected.Clear();
                    if (hovering != null && tr_CurrentlySelected.ContainsKey(hovering) == false)
                    {
                        tr_CurrentlySelected.Add(hovering, new MouseCoordinateStore(tr_MouseDown, tr_MouseDownPoint, tr_MouseCurrentPoint, tr_MouseDifference));
                        hovering.Selected = true;
                        tr_LastHoveredOver = hovering;
                    }
                }
                else if (b.Button == MouseButtons.Right)
                {
                    if (hovering.Selected == true)
                    {
                        MessageBox.Show("Show Right Click Logic Here");
                    }
                    else
                    {
                        foreach (var t in tr_CurrentlySelected)
                        {
                            t.Key.Selected = false;
                        }
                        tr_CurrentlySelected.Clear();
                        if (hovering != null && tr_CurrentlySelected.ContainsKey(hovering) == false)
                        {
                            tr_CurrentlySelected.Add(hovering, new MouseCoordinateStore(tr_MouseDown, tr_MouseDownPoint, tr_MouseCurrentPoint, tr_MouseDifference));
                            hovering.Selected = true;
                            tr_LastHoveredOver = hovering;
                        }
                        MessageBox.Show("Show Right Click Logic Here");
                    }
                }
            });
            item.MouseUp += new MouseEventHandler((a, b) => { tr_MouseDown = false; mouseupdate(); });
            item.MouseMove += new MouseEventHandler((a, b) => { 
                tr_MouseCurrentPoint = this.PointToClient(b.Location); 
                mouseupdate();
                if (tr_MouseDown)
                {
                    MessageBase hovering = this.GetChildAtPoint(tr_MouseCurrentPoint) as MessageBase;
                    if (hovering != null)
                    {
                        if (tr_CurrentlySelected.ContainsKey(hovering) == false)
                        {
                            tr_CurrentlySelected.Add(hovering, new MouseCoordinateStore(tr_MouseDown, tr_MouseDownPoint, tr_MouseCurrentPoint, tr_MouseDifference));
                            tr_LastHoveredOver = hovering;
                            hovering.Selected = true;
                        }
                        else
                        {
                            int ind = hovering.Index;
                            List<MessageBase> ItemsToRemove = new List<MessageBase>();
                            if (tr_MouseDifference.Y < 0) // Y is negative
                            {
                                foreach (var dic in tr_CurrentlySelected)
                                {
                                    if (dic.Key.Index < ind)
                                    {
                                        ItemsToRemove.Add(dic.Key);
                                    }
                                }
                            }
                            else //Y is positive
                            {
                                foreach (var dic in tr_CurrentlySelected)
                                {
                                    if (dic.Key.Index > ind)
                                    {
                                        ItemsToRemove.Add(dic.Key);
                                    }
                                }
                            }
                            foreach (var dic in ItemsToRemove)
                            {
                                tr_CurrentlySelected.Remove(dic);
                                dic.Selected = false;
                            }
                        }
                    }
                }
            });
            item.KeyDown += new KeyEventHandler((a, b) =>
            {
                try
                {
                    if (b.KeyData == Keys.Down)
                    {
                        MessageBase hovering = ControlCollection[tr_LastHoveredOver.Index + 1];
                        foreach (var t in tr_CurrentlySelected)
                        {
                            t.Key.Selected = false;
                        }
                        tr_CurrentlySelected.Clear();
                        if (hovering != null && tr_CurrentlySelected.ContainsKey(hovering) == false)
                        {
                            tr_CurrentlySelected.Add(hovering, null);
                            hovering.Selected = true;
                            tr_LastHoveredOver = hovering;
                        }
                    }
                    else if (b.KeyData == Keys.Up)
                    {
                        MessageBase hovering = ControlCollection[tr_LastHoveredOver.Index - 1];
                        foreach (var t in tr_CurrentlySelected)
                        {
                            t.Key.Selected = false;
                        }
                        tr_CurrentlySelected.Clear();
                        if (hovering != null && tr_CurrentlySelected.ContainsKey(hovering) == false)
                        {
                            tr_CurrentlySelected.Add(hovering, null);
                            hovering.Selected = true;
                            tr_LastHoveredOver = hovering;
                        }
                    }
                }
                catch { }
            });
            #endregion
