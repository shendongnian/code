    List<Dictionary<string, object>> mydic = Yaml.Deserialize(reader).Query(".pods[*].name").AsList;
                    foreach(Dictionary<string, object> wiii in mydic)
                    {
                        bool value = false;
                        if (wiii.ContainsKey("yourKeyname"))
                            value = (bool)wiii["yourKeyname"]; //<-- Here you can cast it in the type you wish
                    }
