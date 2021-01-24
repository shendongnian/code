    DateTime dt;
    cmd.Parameters.Add("@dia", SqlDbType.DateTime);
    if (DateTime.TryParse(idatxt.Text, out dt))
    {
    	cmd.Parameters["@dia"].Value = dt;
    }
    else
    {
    	cmd.Parameters["@dia"].Value = DBNull.Value;
    }
