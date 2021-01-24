        var builder = new System.Text.StringBuilder();
		foreach (string item in tAdim)
        {
            builder.Append(item).Append(",");
        }
		sqlcomm.Parameters.AddWithValue("@builder", builder.ToString());
