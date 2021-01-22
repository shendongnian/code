    SPList list = web.Lists["MyLibrary"];
                if (list != null)
                {
                    var results = from SPListItem listItem in list.Items
                                  select new 
                                  {
                                      xxx = (string)listItem["FieldName"]),
                                      yyy  = (string)listItem["AnotherField"],
                                      zzz = (string)listItem["Field"]
                                  };
                }
