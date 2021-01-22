    var newSet = set.Aggregate(new List<DestinationType>(),
                                        (list, item) =>
                                        {
                                            list.Add(new DestinationType(item.A, item.B, item.C));
                                            return list;
                                        });
