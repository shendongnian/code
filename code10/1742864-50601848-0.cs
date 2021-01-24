                 using (someEntites dc = new someEntites())
                    {
                        //var listForRemoval = (from a in dc.someTable
                                         //where a.Year == 2018 && a.month == 04
                                         //select a).ToList();
                        //if (listForRemoval != null)
                        //{
                          //  dc.someTable.RemoveRange(listForRemoval);
                           // dc.SaveChanges();
                        //}
                      dc.Database.ExecuteStoreCommand("DELETE FROM someTable WHERE Year = {0} AND month = {1}", 2018, 4); // Executes a commande with parameters. You can add more parameters separated by ','.
                    }
