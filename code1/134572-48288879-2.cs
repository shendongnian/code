    using Newtonsoft.Json;
    ...
    List<string> ages = new List<string>();
    foreach (ListItem item in ddlAge.Items)
      if (item.Selected)
        ages.Add(item.Text);
    sqlComm.CommandText = @"SELECT * from TableA WHERE Age IN (
        select value from OPENJSON(@Ages)";
    sqlComm.Parameters.Add("@Ages", SqlDbType.NVarChar);
    sqlComm.Parameters["@Ages"].Value = JsonConvert.SerializeObject(ages);
