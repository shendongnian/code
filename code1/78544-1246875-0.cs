    var results = from i in passwordData.Tables["PasswordValue"].AsEnumerable()
                  let fields = new {
                      Key = i.Field<String>("Key"),
                      Username = i.Field<String>("Username"),
                      Other = i.Field<String>("Other") }
                  let matches = new {
                      Key = r.IsMatch(fields.Key.Replace(" ","")),
                      Username = r.IsMatch(fields.Username.Replace(" ","")),
                      Other = r.IsMatch(fields.Other.Replace(" ","")) }
                  where matches.Key | matches.Username | matches.Other
                  orderby matches.Key descending, fields.Key,
                  matches.Username descending, fields.Username,
                  matches.Other descending, fields.Other
                  select i;
