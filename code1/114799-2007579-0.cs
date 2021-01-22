        protected override void OnMouseDown(MouseEventArgs e)
        {
            int hitRowIndex = HitTest(e.X, e.Y).RowIndex;
            if ((!SelectedRows.Contains(Rows[hitRowIndex])) || ((ModifierKeys & Keys.Control) != Keys.None))
            {
                base.OnMouseDown(e);
            }
        }
