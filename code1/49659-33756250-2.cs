							public class QueryParams : Dictionary<string,string>
				{
					private Uri originolUrl;
					public QueryParams(Uri url)
					{
						this.originolUrl = url;
						//check uri to see if it has a query
						if (url.Query.Count() > 1)
						{
							//we grab the query and strip of the question mark as we do not want it attached
							string query = url.Query.TrimStart("?".ToArray());
							//we grab each query and place them into an array
							string[] parms = query.Split("&".ToArray());
							foreach (string str in parms)
							{
								// we split each query into two strings(key) and (value) and place into array
								var param = str.Split("=".ToArray());
								//we add the strings to this dictionary
								this.Add(param[0], param[1]);
							}
						}
					}
         
					public QueryParams SetQueryParam(string paramName, string value)
					{
            
						if(this.ContainsKey(paramName))
						{
							//if key exists change value
							this[paramName] = value;
							return (this);
						}
            
						return (this);
					}
					public QueryParams SetQueryParam(string paramName, int value)
					{
						if (this.ContainsKey(paramName))
						{
							//if key exists change value
							this[paramName] = value.ToString();
							return (this);
						}
						return (this);
					}
       
					public void Add(string key, int value)
					{
						//overload, adds a new keypair
						var strValue = value.ToString();
						this.Add(key, strValue);
					}
					public override string ToString()
					{
						StringBuilder sb = new StringBuilder();
						foreach (KeyValuePair<string, string> pair in this)
						{
							//we recreate the query from each keypair 
							sb.Append(pair.Key + "=" + pair.Value + "&");
						}
						//trim the end of the query
						var modifiedQuery = sb.ToString().TrimEnd("&".ToArray());
						if (!modifiedQuery.StartsWith("?") && this.Count() > 0)
						{
							//replace the question mark only if a query exists and join 
							var query = modifiedQuery.Insert(0, "?");
							var joined = replaceQuery(query);
							return joined;
						}
						else
						{
						   var joined = replaceQuery(modifiedQuery);
						   return joined;
						}
					}
        
					public string replaceQuery(string query)
					{
						var joined = String.Concat(originolUrl.GetLeftPart(UriPartial.Path), query);
						return joined;
					}
					public Uri ToUri()
					{
					   var strUrl = this.ToString();
					   Uri newUri = new Uri(strUrl);
					   return newUri;
					}
        
        
				}
				public class implementation
				{
					Uri url = new Uri("https://www.google/map/cgi-bin?q=&geo=&distance=1&search=1&fp=1");
				public Uri changeQuery()
					 {
						 QueryParams pc = new QueryParams(url);
						 pc.Add("size", 10);
						 pc.Add("area", "250");
						 Uri ammended = pc.SetQueryParam("distance", "10").SetQueryParam("search", 15).SetQueryParam("fp", "5").ToUri();
						 string ammend = pc.SetQueryParam("geo", "geobird").SetQueryParam("q", "10").SetQueryParam("search", 8).SetQueryParam("fp", "2").ToString();
						 return ammended;
					 }
				}
			}
