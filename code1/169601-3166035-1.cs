            var r = from i in myList
                group i by new { i.Number, i.CurrentStatus }
                    into grp
                    select new
                    {
                        Reported = grp.Key.CurrentStatus,
                        Number = grp.Key.Number,
                        Sum = grp.Sum(x => x.Details[0].Quantity),
                        Name = grp.Select(x => x.Name).First(),
                        Details = grp.Select(x => x.Details).First(),
                        Descriptions = grp.Select(x => x.Descriptions).First(),
                        AssignmentId = grp.Select(x => x.AssignmentId).First(),
                        Listor = grp.Select(x => x.Number).Count()
                    };
