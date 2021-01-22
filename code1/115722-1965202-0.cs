       Point theLoc = DG.PointToClient(new Point(e.X, e.Y));
            DataGridView.HitTestInfo theHit = DG.HitTest(theLoc.X,theLoc.Y);
            int theCol = theHit.ColumnIndex;
            int theRow = theHit.RowIndex;
            MessageBox.Show(theCol.ToString() + " " + theRow.ToString());
