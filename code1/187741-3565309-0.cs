                    lookUpForResult = result.ToLookup(x => x.Key.InnerID, x => x.Value);
                    if (lookUpForResult.Contains(calc.InnerID))
                    {
                        result.Add(calc, new List<PropertyValue> { propValue });
                    }
                    else
                    {
                       (lookUpForResult[calc.InnerID]).Add(propValue);
                    }
