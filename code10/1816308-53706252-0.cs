     foreach (WIA.Property prop in WiaDev.Properties)
                    {
                        Console.WriteLine(prop.Name + " - " + prop.PropertyID + " :  " + prop.get_Value() + "  No range");
                        if (prop.SubType == WiaSubType.ListSubType || prop.SubType == WiaSubType.FlagSubType)
                        {
                            Vector v = prop.SubTypeValues;
                            var enumerator = v.GetEnumerator();
                            while (enumerator.MoveNext())
                                Console.WriteLine("Possible Values: " + enumerator.Current);
                        }
                    }
                    Console.WriteLine("---------------------------------");
                    foreach (WIA.Property prop in Item.Properties)
                    {
                        if (prop.SubType == WiaSubType.RangeSubType)
                        {
                            Console.WriteLine(prop.Name + " - " + prop.PropertyID + " :  " + prop.get_Value() + "  Min: " + prop.SubTypeMin + " Max: " + prop.SubTypeMax);
                        }
                        else
                        {
                            Console.WriteLine(prop.Name + " - " + prop.PropertyID + " :  " + prop.get_Value() + "  No range");
                        }
                        if (prop.SubType == WiaSubType.ListSubType || prop.SubType == WiaSubType.FlagSubType)
                        {
                            Vector v = prop.SubTypeValues;
                            var enumerator = v.GetEnumerator();
                            while (enumerator.MoveNext())
                                Console.WriteLine("Possible Values: " + enumerator.Current);
                        }
                    }
    
