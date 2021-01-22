        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            _lastNode = null;
            _mouseDown = true;
        }
        private void treeView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                var hitTestInfo = treeView1.HitTest(e.Location);
                if (hitTestInfo.Location == TreeViewHitTestLocations.StateImage 
                   && hitTestInfo.Node != _lastNode)
                {
                    _lastNode = hitTestInfo.Node;
                    hitTestInfo.Node.Checked = !hitTestInfo.Node.Checked;
                }
                else
                {
                    _lastNode = null;
                }
            }
        }
        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            _lastNode = null;
            _mouseDown = false;
        }
