			Dictionary<string, DateTime> d = new Dictionary<string, DateTime>();
			d.Add("rsgfdg", DateTime.Now);
			d.Add("gfdsgd", DateTime.Now);
			
			Dictionary<object, object> newDictionary = DeTypeDictionary<string, DateTime>(d);
