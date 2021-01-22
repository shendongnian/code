    while (dr.Read())
    {
        try
        {
          string itemValue = dr["fldMachine_ID"].ToString();
          string flatName =  dr["fldMachineName"].ToString();
          if (string.IsNullOrEmpty(flatName)) flatName = "!NULL!";
          if (string.IsNullOrEmpty(itemValue)) itemValue = "!NULL!";
          items.Add(flatName, itemValue);
          string rotaryName = dr["fldRotaryPressName"].ToString();
          if (string.IsNullOrEmpty(rotaryName)) rotaryName= "!NULL!";
          items.Add(rotaryName, itemValue);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString());
        }
    }
    // Bind list to ddl.
    machines.DataSource = items;
    machines.DataValueField = "Value";
    machines.DataTextField = "Key";
    machines.DataBind();
    machines.Enabled = true;
