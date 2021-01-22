    var charId= int.Parse(Request.Params["charId"]);
    EveFPT ctx = new EveFPT();
    var theChar = ( from a in ctx.tblChars.Include ( "tblCorps" )
                    where a.id == charId
                    select new
                    {
                        Name = a.name,
                        CorpName = a.tblCorps.name,
                        AllianceName = a.tblCorps.tblAlliances.name
                    } ).FirstOrDefault ();
    if(theChar != null)
    {
        lblCharName.Text = theChar.Name;
        lblCorpName.Text = theChar.CorpName;
        lblAllianceName.Text = theChar.AllianceName;
    }
