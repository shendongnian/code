                  if (Items.Count() != 0)
                  {
                        int pageNumber = Total Records / 50;
                              for (int num = 0; numi < pageNumber; num++)
                              {
                                    var x = Items.Skip(i * pageSize).Take(pageSize);
                                    i++;
                              }
                        var y = Items.Skip(i * pageSize).Take(pageSize);
                  }
