    class ListViewItemComparer : System.Collections.Generic.IComparer<ListViewItem>
    {
        int[] mColonne;
        private System.Windows.Forms.SortOrder order;
        public ListViewItemComparer(int[] mCols)
        {
            this.mColonne = mCols;
            this.order = System.Windows.Forms.SortOrder.Ascending;
        }
    
        public ListViewItemComparer(int[] mCols, System.Windows.Forms.SortOrder order)
        {
            this.mColonne = mCols;
            this.order = order;
        }
    
        public int Compare(ListViewItem x, ListViewItem y)
        {
            int returnVal = -1;
    
            foreach (int mColonna in mColonne)
            {
                double mNum1;
                double mNum2;
    
                String mStr1 = "";
                String mStr2 = "";
    
                if ((x.SubItems[mColonna].Text == "NULL") && (x.SubItems[mColonna].ForeColor == Color.Red))
                {
                    mStr1 = "-1";
                }
                else
                {
                    mStr1 = x.SubItems[mColonna].Text;
                }
    
                if ((y.SubItems[mColonna].Text == "NULL") && (y.SubItems[mColonna].ForeColor == Color.Red))
                {
                    mStr2 = "-1";
                }
                else
                {
                    mStr2 = y.SubItems[mColonna].Text;
                }
    
    
                if ((double.TryParse(mStr1, out mNum1) == true) && (double.TryParse(mStr2, out mNum2) == true))
                {
                    if (mNum1 == mNum2)
                    {
                        returnVal = 0;
                    }
                    else if (mNum1 > mNum2)
                    {
                        returnVal = 1;
                    }
                    else
                    {
                        returnVal = -1;
                    }
                }
                else if ((double.TryParse(mStr1, out mNum1) == true) && (double.TryParse(mStr2, out mNum2) == false))
                {
                    returnVal = -1;
                }
                else if ((double.TryParse(mStr1, out mNum1) == false) && (double.TryParse(mStr2, out mNum2) == true))
                {
                    returnVal = 1;
                }
                else
                {
                    returnVal = String.Compare(mStr1, mStr2);
                }
    
                if (returnVal != 0)
                {
                    break;
                }
            }
    
            // Determine whether the sort order is descending.
            if (order == System.Windows.Forms.SortOrder.Descending)
            {
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            }
            return returnVal;
        }
    }
