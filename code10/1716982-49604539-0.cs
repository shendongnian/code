                foreach (var p in singleNameWithOldestPrice)
                {
                    foreach (var pp in p)
                    {
                        source.Add(new Entry(pp.price)
                        {
                            Label = "Name",
                            ValueLabel = pp.price.ToString(),
                            Color = SKColor.Parse("#f79c00")
                        });
                    }
                }
