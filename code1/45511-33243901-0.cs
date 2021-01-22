                var list1 = new List<ItemOne>
                            {
                                new ItemOne {IDItem = 1, OneProperty = "1"},
                                new ItemOne {IDItem = 2, OneProperty = null},
                                new ItemOne {IDItem = 3, OneProperty = "3"},
                                new ItemOne {IDItem = 4, OneProperty = "4"}
                            };
            var list2 = new List<ItemTwo>
                            {
                                new ItemTwo {IDItem = 2, TwoProperty = "2"},
                                new ItemTwo {IDItem = 3, TwoProperty = "3"},
                            };
            var query = list1.Join(list2, l1 => l1.IDItem, l2 => l2.IDItem, (l1, l2) =>
            {
                l1.OneProperty = l2.TwoProperty;
                return l1;
            });
