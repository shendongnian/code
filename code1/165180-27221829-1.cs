    private void populateCombos()
        {
            persist.ShowLst(dspMember, vlMember,varTable,lstBox,varWhere);
            persist.ShowLst(dspMember, vlMember,varTable,ddlist1,varWhere);
            persist.ShowLst(dspMember, vlMember,varTable, ddlist2,varWhere);
            ddList1.Text = null;
            ddList2.Text = null;
            
            lstBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            lstBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            lstBox.Text = null;
        }
