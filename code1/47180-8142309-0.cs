    cf.ApplyAlignment = true;//Set this so that Excel knows to use it.
    if (cf.Alignment == null)//If no pre-existing Alignment, then add it.
      cf.Alignment = new Alignment() { WrapText = true };
    Alignment a = cf.Alignment;
    if (a.WrapText == null || a.WrapText.Value == false)
      a.WrapText = new BooleanValue(true);//Update pre-existing Alignment.
