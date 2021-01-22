      if (this.TableLayoutPanel1.HorizontalScroll.Visible)
      {
        int newWid = this.TableLayoutPanel1.Width -
                      (2 * SystemInformation.VerticalScrollBarWidth);
        //this.TableLayoutPanel1.Padding = new Padding(0, 0, newWid, 0);
        foreach (Control ctl in this.TableLayoutPanel1.Controls)
        {
          ctl.Width = newWid;
        }
      }
