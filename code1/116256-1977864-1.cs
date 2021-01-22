    const string propPrefix = "UserVar";
    VendorObj o = new VendorObj();
    foreach (var item in userVars)
    {
        int varNum = 0;
        if (Int32.TryParse(item.VariableName, out varNum))
        {
            string name = String.Format("{0}Nbr{1}", propPrefix, varNum);
            o.GetType().GetProperty(name).SetValue(o, "some value", null);
        }
    }
