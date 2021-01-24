    public void Drop(IDropInfo dropInfo) 
    {
        MSP msp = (MSP)dropInfo.Data;
  	    if(dropInfo.DragInfo.SourceCollection != dropInfo.TargetCollection)
	    {
		    ((IList)dropInfo.DragInfo.SourceCollection).Remove(msp);
		    ((IList)dropInfo.TargetCollection).Add(msp);
	    }
    }
