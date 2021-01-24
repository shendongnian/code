     var query = (from it in context.Items
                         join ie in context.ItemEntity on new { ItemID = it.ID }
                                    equals new { ItemID = ie.ItemID } into itLeft
                         from itJoin in itLeft.DefaultIfEmpty()
                         where itJoin != null && itJoin.ItemID == it.ItemID && ((itJoin.EntityID == 1 && (itJoin.EntityID != 2 || itJoin.EntityID != 3) || (itJoin.EntityID == 2 && itJoin.EntityID != 3) || (itJoin.EntityID == 3 && itJoin.EntityID != 2))
                         select it);
