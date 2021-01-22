    protected string specialField = null;
    public string SpecialField
    {
        get
        {
            if (specialField == null)
            {
                specialField = string.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}",
                                 TableId,
                                 Number,
                                 ForeignTableA.Date,
                                 ForeignTableB.Name,
                                 ForeignTableC.ForeignTableD.Name,
                                 ForeignTableB.ForeignTableE.Name,
                                 ForeignTableB.Number ?? 0);
            }
            return specialField;
        }
    }
