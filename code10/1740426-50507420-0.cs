                string data= string.Empty;
				int indeks = read.GetOrdinal("columnname");
				if (!read.IsDBNull(indeks))
				{
					data= read.GetString(indeks);
				}
