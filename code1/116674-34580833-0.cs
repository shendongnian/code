            //---------------------------------------------------
            // Get a nested Dictionary, then...
            Console.WriteLine(DictionaryPrint(nestedDictionary));
            //---------------------------------------------------
            private static string DictionaryPrint(Dictionary<object,object> dictionary, string space = "")
            {
                string output = "";
                foreach(KeyValuePair<object,object> entry in dictionary)
                {
                    output += space + entry.Key + ": ";
                    if (entry.Value is Dictionary<object, object>)
                        output += "\n" + DictionaryPrint((Dictionary<object, object>)entry.Value, space + "  ");
                    else if (entry.Value is List<object>)
                        output += "\n" + ListPrint((List<object>)entry.Value, space + "  ");
                    else
                        output += entry.Value + "\n";
                }
                return output;
            }
    
            private static string ListPrint(List<object> list, string space = "")
            {
                string output = "";
                foreach (object entry in list)
                {
                    if (entry is List<object>)
                        output += ListPrint((List<object>)entry, space + "  ");
                    else if (entry is Dictionary<object, object>)
                        output += DictionaryPrint((Dictionary<object, object>)entry, space + "  ");
                    else
                        output += entry + "\n";
                }
                return output;
            }
