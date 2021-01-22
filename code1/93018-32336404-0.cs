        private void MyDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = this.MyDataGridView.HitTest(e.X, e.Y);
            if (hitInfo.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                MyDataGridView.ClearSelection();
            }
         }
