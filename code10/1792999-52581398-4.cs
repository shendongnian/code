    public void DrawVisualStyleElementRebarGripper1(PaintEventArgs e)
    {
        if (VisualStyleRenderer.IsElementDefined(
            VisualStyleElement.Rebar.Gripper.Normal))
        {
            VisualStyleRenderer renderer =
                    new VisualStyleRenderer(VisualStyleElement.Rebar.Gripper.Normal);
            Rectangle rectangle1 = new Rectangle(0, 0, 
                                                20,  (int)e.Graphics.VisibleClipBounds.Height);
            renderer.DrawBackground(e.Graphics, rectangle1);
        }
        //else
        //    e.Graphics.DrawString("This element is not defined in the current visual style.",
        //            this.Font, Brushes.Black, new Point(10, 10));
    }
