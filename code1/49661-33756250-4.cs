       public class QueryParams : Dictionary<string,string>
       {
           private Uri originolUrl;
           private Uri ammendedUrl;
           private string schemeName;
           private string hostname;
           private string path;
          
           public QueryParams(Uri url)
           {
               this.originolUrl = url;
               schemeName = url.Scheme;
               hostname = url.Host;
               path = url.AbsolutePath;
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
                       string[] param = str.Split("=".ToArray());
                       //we add the strings to this dictionary
                       this.Add(param[0], param[1]);
                   }
               }
           }
   
   
           public QueryParams Set(string paramName, string value)
           {
               
               if(this.ContainsKey(paramName))
               {
                   //if key exists change value
                   this[paramName] = value;
                   return (this);
               }
               else
               {
                   this.Add(paramName, value);
                   return this;
               }
           }
           public QueryParams Set(string paramName, int value)
           {
               if (this.ContainsKey(paramName))
               {
                   //if key exists change value
                   this[paramName] = value.ToString();
                   return (this);
               }
               else 
               {
                   this.Add(paramName, value);
                   return this;
               }
           }
          
           public void Add(string key, int value)
           {
               //overload, adds a new keypair
               string strValue = value.ToString();
               this.Add(key, strValue);
           }
   
           public override string ToString()
           {
               StringBuilder queryString = new StringBuilder();
   
               foreach (KeyValuePair<string, string> pair in this)
               {
                   //we recreate the query from each keypair 
                   queryString.Append(pair.Key + "=" + pair.Value + "&");
               }
               //trim the end of the query
               string modifiedQuery = queryString.ToString().TrimEnd("&".ToArray());
              
               if (this.Count() > 0)
               {
                   UriBuilder uriBuild = new UriBuilder(schemeName, hostname);
                   uriBuild.Path = path;
                   uriBuild.Query = modifiedQuery;
                   ammendedUrl = uriBuild.Uri;
                   return ammendedUrl.AbsoluteUri;
               }
               else
               {
                   return originolUrl.ToString();
               }
           }
           
          
           public Uri ToUri()
           {
              this.ToString();
              return ammendedUrl;
           }
       }
    }
