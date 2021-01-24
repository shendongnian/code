                 string where =string.Empty;
                if (!string.IsNullOrWhiteSpace(name))
                          where + = name;
               if (!string.IsNullOrWhiteSpace(category))
                          where += category;
               if (!string.IsNullOrWhiteSpace(rarity))
                            where += rarity;
                   var entity = 
                        setFilter(context.MagicItems,where,order)
                    Return entity;
