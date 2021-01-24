    foreach (var x in allItems)
            {
                foreach (var y in x.Combination)
                {
                    if (y.Index == 0)
                    {
                        y.ItemCount = 105;
                    }
                }
            }
