    var Lookup = Lines.Entities.Where(e => e.GetAttributeValue<OptionSetValue>("new_time").Value == 100000001).Select(r => new
                        {
                            group = r.GetAttributeValue<OptionSetValue>("new_group").Value,
                            desc = r.GetAttributeValue<string>("new_desc"),
                            numbers = new Dictionary<string, int>()
                            {
                                {"monday", r.GetAttributeValue<int>("new_mondayunits") },
                                {"tuesday", r.GetAttributeValue<int>("new_tuesdayunits") },
                                {"wednesday", r.GetAttributeValue<int>("new_wednesdayunits") },
                                {"thursday", r.GetAttributeValue<int>("new_thursdayunits") },
                                {"friday", r.GetAttributeValue<int>("new_fridayunits") }
                            }
                        }).ToDictionary(t => t.group.ToString() + t.desc, t => t.numbers);
    var quan = Lookup.ContainsKey(key) ? amLookup[key][currentday] : 0;
