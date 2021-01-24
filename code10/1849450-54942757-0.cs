	var query = _Session.CreateSQLQuery("SELECT 'just a string' as Type, NAME  FROM SCHEMA.PERSON where NAME like ('%A%')").SetResultTransformer(Transformers.AliasToEntityMap);
	var result = query.List();
	var tab = new DataTable();
	if (result.Count > 0)
	{
		var asHash = result[0] as Hashtable;
		foreach (DictionaryEntry item in asHash)
		{
			tab.Columns.Add(item.Key as string);
		}
		foreach (Hashtable item in result)
		{
			var newobj = new Object[tab.Columns.Count];
			int i = 0;
			foreach (DictionaryEntry row in item)
			{
				newobj[i]= row.Value;
				i++;
			}
			tab.Rows.Add(newobj);
		}
	}
	this.results.DataSource = tab; 
