    public void AutoSizeColumns()
    {
        GridView gv = listView1.View as GridView;
        if (gv != null)
        {
            foreach (var c in gv.Columns)
            {
                // Code below was found in GridViewColumnHeader.OnGripperDoubleClicked() event handler (using Reflector)
                // i.e. it is the same code that is executed when the gripper is double clicked
                if (double.IsNaN(c.Width))
                {
                    c.Width = c.ActualWidth;
                }
                c.Width = double.NaN;
            }
        }
    }
