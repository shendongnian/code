                        if (entityKey.EntityKeyValues != null && entityKey.EntityKeyValues.Any())
                        {
                            DbEntityEntry<T> entry =
                                this.context.Entry(this.dbset.Find(entityKey.EntityKeyValues.FirstOrDefault().Value));
                            entry.CurrentValues.SetValues(entityToUpdate);
                        }
                    }
                    this.context.SaveChanges();
