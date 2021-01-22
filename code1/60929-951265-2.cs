		public string NameValueCollectionToString(NameValueCollection nvc, char KeyValueSeparator, char ItemSeparator)
		{
			StringBuilder sb = new StringBuilder();
			
			for(int i = 0; i < nvc.Count; i++)
			{
				if (i != 0)
				{
					sb.Append(ItemSeparator);
				}
				sb.Append(nvc.Keys[i]);
				sb.Append(KeyValueSeparator);
				sb.Append(nvc[i]);
			}
			return sb.ToString();
		}
