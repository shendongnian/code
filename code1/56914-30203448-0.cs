        #region Synchronize the scrolling of the two panels in the SplitContainer.
        private Point _prevPan1Pos = new Point();
        private Point _prevPan2Pos = new Point();
        void PanelPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            SynchronizeSplitContainerScrollbars();
        }
        private void SynchronizeSplitContainerScrollbars()
        {
            if (splitContainer1.Panel1.AutoScrollPosition != _prevPan1Pos)
            {
                splitContainer1.Panel2.AutoScrollPosition = new System.Drawing.Point(-splitContainer1.Panel1.AutoScrollPosition.X, -splitContainer1.Panel1.AutoScrollPosition.Y);
                _prevPan1Pos = splitContainer1.Panel1.AutoScrollPosition;
            }
            else if (splitContainer1.Panel2.AutoScrollPosition != _prevPan2Pos)
            {
                splitContainer1.Panel1.AutoScrollPosition = new System.Drawing.Point(-splitContainer1.Panel2.AutoScrollPosition.X, -splitContainer1.Panel2.AutoScrollPosition.Y);
                _prevPan2Pos = splitContainer1.Panel2.AutoScrollPosition;
            } 
        }
        #endregion
