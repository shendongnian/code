    var userItems = new[] {
                new UserItem(926, 1, "TaylorFrank", 6, 7),
                new UserItem(839, 2, "Jonathan M", 4, 7),
                new UserItem(933, 2, "Jonathan M", 6, 7),
                new UserItem(689, 3, "Max Terry", 4, 7),
                new UserItem(925, 3, "Max Terry", 6, 7),
                new UserItem(932, 4, "Frank M", 4, 7),
                new UserItem(931, 4, "Frank M", 6, 7),
                new UserItem(691, 5, "Stephanie K", 4, 7),
                new UserItem(809, 14, "Kevin McCannon", 4, 7),
                //duplication for group  (x.ItemId, x.ItemTypeId )
                new UserItem(1926, 1, "TaylorFrank", 6, 7),
                new UserItem(1839, 2, "Jonathan M", 4, 7),
                new UserItem(1933, 2, "Jonathan M", 6, 7),
                new UserItem(1689, 3, "Max Terry", 4, 7),
                new UserItem(1925, 3, "Max Terry", 6, 7),
                new UserItem(1932, 4, "Frank M", 4, 7),
                new UserItem(1931, 4, "Frank M", 6, 7),
                new UserItem(1691, 5, "Stephanie K", 4, 7),
                new UserItem(1809, 14, "Kevin McCannon", 4, 7),
            };
            var groupedByItemAndType =
                userItems
                .GroupBy(x => new { x.ItemId, x.ItemTypeId })
                .Where(g => g.Count() > 1);
            var distinctUsersInGroup =
                groupedByItemAndType
                .Select(g => new { g.Key, distinctUsers = g.Select(ui => ui.Initials).Distinct() });
            foreach(var item in distinctUsersInGroup)
            {
                Console.WriteLine($"group: {item.Key}, {string.Join("; ", item.distinctUsers)}");
            }
