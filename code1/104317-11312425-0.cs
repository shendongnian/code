        protected virtual void NestedControl_Mousemove(object sender, MouseEventArgs e)
        {
            Control current = sender as Control;
            //you will need to edit this to identify the true parent of your top-level control. As I was writing a custom UserControl, "this" was my title-bar's parent.
            if (current.Parent != this) 
            {
                // Reconstruct the args to get a correct X/Y value.
                // you can ignore this if you never need to get e.X/e.Y accurately.
                MouseEventArgs newArgs = new MouseEventArgs
                (
                    e.Button, 
                    e.Clicks, 
                    e.X + current.Location.X, 
                    e.Y + current.Location.Y, 
                    e.Delta
                );
                NestedControl_Mousemove(current.Parent, newArgs);
            }
            else
            {
                // My "true" MouseMove handler, called at last.
                TitlebarMouseMove(current, e);
            }
        }
        //helper method to basically just ensure all the child controls subscribe to the NestedControl_MouseMove event.
        protected virtual void AddNestedMouseHandler(Control root, MouseEventHandler nestedHandler)
        {
            root.MouseMove += new MouseEventHandler(nestedHandler);
            if (root.Controls.Count > 0)
                foreach (Control c in root.Controls)
                    AddNestedMouseHandler(c, nestedHandler);
        }
