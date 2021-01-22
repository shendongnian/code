    var builder = new StringBuilder();
    var listParams = CheckBoxList1.Items
                         .Where(li => li.Selected)
                         .Select(li, idx => new 
                         {
                             PhoneString = String.Format("@phone_id{0}", idx),
                             PhoneValue = GetPhoneId(li),
                             ResourceString = String.Format("@resource_id{0}", idx),
                             ResourceValue = GetResourceId(li)
                         };
    foreach (var param in listParams)
    {
        builder.AppendFormat("INSERT INTO phones_resources (phone_id, resource_id) 
                              VALUES ({0}, {1});", 
                              param.PhoneString, param.ResourceString);
    }
    SqlCommand cmd = new SqlCommand(builder.ToString(), conn);
    foreach (var param in listParams)
    {
        cmd.Parameters.AddWithValue(param.PhoneString, param.PhoneValue);
        cmd.Parameters.AddWithValue(param.ResourceString, param.ResourceValue);
    }
