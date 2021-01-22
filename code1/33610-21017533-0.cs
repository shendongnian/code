        public class CustomRenderer: ToolStripProfessionalRenderer
        {
            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Enabled) //in this case you will just have the image in your button, you need to add text etc in this if
                {
                     //to repaint the image
                     Graphics g = e.Graphics;
                     g.DrawImageUnscaled(e.Item.Image, new Point(2, 2))); //you need to specify the correct position
                }
                else //other cases
                    base.OnRenderButtonBackground(e);
             }
        }
