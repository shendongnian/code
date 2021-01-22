    void control_RightMouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right)
        {
            return;
        }
        if (sender.GetType().IsSubclassOf(typeof(Control)))
        {
            Control formControl = (Control)sender;
            switch (formControl.Name)
            {
                case "label_1":
                    //do something
                    contextMenuStrip1.Show(formControl, e.Location);
                    break;
                case "label_2":
                    //do something else
                    contextMenuStrip2.Show(formControl, e.Location);
                    break;
                case "label_3":
                    //do something else
                    contextMenuStrip3.Show(formControl, e.Location);
                    break;
                case "panel_1":
                    //do something else
                    break;
                default:
                    //do something else or return or show default context menu
                    contextMenuStrip_default.Show(formControl, e.Location);
                    break;
            }
        }
        return;
    }
