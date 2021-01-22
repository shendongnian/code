    internal class MyTree : TreeView
    {
        internal MyTree() :
            base()
        {
            // let the tree know that we're going to be doing some owner drawing
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.DrawNode += new DrawTreeNodeEventHandler(MyTree_DrawNode);
        }
        void MyTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            // Do your own logic to determine what overlay image you want to use
            Image overlayImage = GetOverlayImage();
            // you have to move the X value left a bit, 
            // otherwise it will draw over your node text
            // I'm also adjusting to move the overlay down a bit
            e.Graphics.DrawImage(overlayImage,
                e.Node.Bounds.X - 15, e.Node.Bounds.Y + 4);
            // We're done! Draw the rest of the node normally
            e.DefaultDraw = true
        }
    }
