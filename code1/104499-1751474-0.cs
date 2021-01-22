    void OrderSummaryDetails_MouseMove(object sender, MouseEventArgs e)
    {
          Control control = GetChildAtPoint(e.Location);
          if (control != null)
          {
              string toolTipString = mFormTips.GetToolTip(control);
              this.mFormTips.ShowAlways = true;
              // trigger the tooltip with no delay and some basic positioning just to give you an idea
              mFormTips.Show(toolTipString, control, control.Width / 2, control.Height / 2);
          }
    }
