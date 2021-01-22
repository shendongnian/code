			public class QueryParams : Dictionary<string,string>
				{
					private Uri originolUrl;
					public QueryParams(Uri url)
					{
						this.originolUrl = url;
						if (url.Query.Count() > 1)
						{
							string[] parms = url.Query.Split("&".ToArray());
							foreach (string str in parms)
							{
								var param = str.Split("=".ToArray());
								this.Add(param[0], param[1]);
							}
						}
					}
					public QueryParams SetQueryParam(string paramName, string value)
					{
						if(this.ContainsKey(paramName))
						{
							this[paramName] = value;
							return (this);
						}
            
						return (this);
					}
       
					public override string ToString()
					{
						StringBuilder sb = new StringBuilder();
						foreach (KeyValuePair<string, string> pair in this)
						{
							sb.Append(pair.Key + "=" + pair.Value + "&");
						}
						var modifiedQuery = sb.ToString().TrimEnd("&".ToArray());
						if (!modifiedQuery.StartsWith("?") && this.Count() > 0)
						{
							var query = modifiedQuery.Insert(0, "?");
							var joined = String.Concat(originolUrl.GetLeftPart(UriPartial.Path), query);
							return joined;
						}
						else
						{
							var path = originolUrl.GetLeftPart(UriPartial.Path);
							var joined = String.Concat(path, modifiedQuery);
							return joined;
						}
					}
        
					public Uri ToUri()
					{
					   var strUrl = this.ToString();
					   Uri newUri = new Uri(strUrl);
					   return newUri;
					}
        
				}
			}
