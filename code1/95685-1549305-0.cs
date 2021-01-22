                    Point p = this.PointToClient(MousePosition);
                    Control x = this.GetChildAtPoint(p);
                    if (x != null)
                    {
                        MessageBox.Show(x.GetType().ToString() + " - " + x.Name);
                    }
