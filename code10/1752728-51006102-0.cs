				TreeIter iter;            
                TreeModel model = tv.Model;
                if (model.GetIterFirst(out iter))
                {
                    do
                    {
						newYear = ModifyYear((string)model.GetValue(iter, (int)Column.Year));
						Console.WriteLine("Updating: {0} -- {1} {2}",
                                      (string)model.GetValue(iter, (int)Column.Name),
                                              model.GetValue(iter, (int)Column.Year),
                                              newYear );
						model.SetValue(iter, (int)Column.Year, (int)newYear);
						
                    } while (model.IterNext(ref iter));
                }
