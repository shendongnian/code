        var items = from aList in dataContext.MyLists
                    from i in aList.MyItems  // Access the items in a list
                    where aList.ID == myId  // Use only the single desired list
                    select
                        new
                            {
                                i.ID,
                                i.Sector,
                                i.Description,
                                CompleteDate = i.CompleteDate.HasValue ? i.CompleteDate.Value.ToShortDateString() : "",
                                DueDate = i.DueDate.HasValue ? i.DueDate.Value.ToShortDateString() : ""
                            };
