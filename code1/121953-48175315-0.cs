    private void chklst_MouseClick(object sender, MouseEventArgs e)
    {
      Point p = chklst.PointToClient(MousePosition);
      int i = chklst.IndexFromPoint(p);
      if (p.X > 15) { return; } // Body click. 
      if (chklst.CheckedIndices.Contains(i)){ return; } // If already has focus click anywhere works right.
     if (iLastIndexClicked == i) { return; } // native code will check/uncheck
      chklst.SetItemChecked(i, true);  
      iLastIndexClicked = i;
    }
