            var format = Pattern.Replace(
                template,
                match =>
                    {
                        var name = match.Groups[1].Captures[0].Value;
                        if (!int.TryParse(name, out parsedInt))
                        {
                            if (!map.ContainsKey(name))
                            {
                                map[name] = map.Count;
                                list.Add(dictionary.ContainsKey(name) ? dictionary[name] : null);
                            }
                            return "{" + map[name] + match.Groups[2].Captures[0].Value + "}";
                        }
                        else return "{{" + name + "}}";
                    }
                );
