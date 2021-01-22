            var node = GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                var text = node.Text;
                if (!text.Equals(toolTipController.GetToolTip(this)))
                {
                    toolTipController.Show(text, this, e.Location, 2000);
                }
            }
            else
            {
                toolTipController.RemoveAll();
            }
        }
