    var bt = new BaseTest();
    bt.ValDesc("");
    //Output is Base.GetDesc: Base GetDesc
    bt.ValDesc("ext");
    //Output is Base.Ext.GetDesc: Extension GetDesc
    bt.ValDesc("ext def");
    //Output is Base.Ext.Ext.GetDesc: Extension GetDesc
    bt.ValDesc("ext base");
    //Output is Base.Ext.Base.GetDesc: Base GetDesc
