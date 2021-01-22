    lvB.EndUpdate();
    lvI.EndUpdate();
    lvR.EndUpdate();
    
    if (lstEntryInts.Items.Count > 0)
        lstEntryInts.TopItem = lstEntryInts.Items[iTopVisIdx];
    if (lstEntryBools.Items.Count > 0)
        lstEntryBools.TopItem = lstEntryBools.Items[iTopVisIdx];
    if (lstEntryReals.Items.Count > 0)
        lstEntryReals.TopItem = lstEntryReals.Items[iTopVisIdx];​
