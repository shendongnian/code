           foreach (DataTable dTable in dataTablesList)
            {
                bool bottomHierarchyReached = true;
                var SearchList = dTable.AsEnumerable().Select(p=> new { HierarchyAccount = p.Field<string>("Hierarchy Account Number"),
                    Account = p.Field<string>("Account Number")
                }).ToList();
                var tempList = SearchList.ToList();
                tempList.Clear();
                while (bottomHierarchyReached)
                {
                    tempList.Clear();
                    foreach (var account in SearchList)
                    {
                        var rows = dataTable.AsEnumerable().Where(m => m.Field<string>("Hierarchy Account Number") == account.Account);
                        if(rows.Count() == 0)
                        {
                            bottomHierarchyReached = false;
                            break;
                        }
                        else
                        {
                            tempList.AddRange(rows.AsEnumerable().Select(p => new {
                                HierarchyAccount = p.Field<string>("Hierarchy Account Number"),
                                Account = p.Field<string>("Account Number")
                            }).ToList());
                            foreach(var row in rows)
                            {
                                dTable.ImportRow(row);
                            }
                        }
                    }
                    SearchList = tempList.ToList();
                }
            }
