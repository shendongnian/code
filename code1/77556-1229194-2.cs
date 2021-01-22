     private void ProcessDrawItem(ref Message m)
            {
                DRAWITEMSTRUCT dis = (DRAWITEMSTRUCT)Marshal.PtrToStructure(m.LParam, typeof(DRAWITEMSTRUCT));
                Graphics g = Graphics.FromHdc(dis.hDC);
                ListViewItem i = this.Items[dis.itemID];
    
                Rectangle rcItem = new Rectangle(dis.rcItem.left, dis.rcItem.top, this.ClientSize.Width, dis.rcItem.Height);
                //we have our rectangle.
                //draw whatever you want
                if (dis.itemState == 17)
                {
                    //item is selected
                    g.FillRectangle(new SolidBrush(Color.Red), rcItem);
                    g.DrawString(i.Text, new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(rcItem.X, rcItem.Y+1));
                }
                else
                {
                    //regular item
                    g.FillRectangle(new SolidBrush(Color.White), rcItem);
                    g.DrawString(i.Text, new Font("Arial", 8), new SolidBrush(Color.Black), new PointF(rcItem.X, rcItem.Y+1));
                }
                
                //we have handled the message
                m.Result = (IntPtr)1;
            }
