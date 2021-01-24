     public int AddOrEdit(DEMO_MAST model)
                {
                    try
                    {
                        var data = context.DEMO_MAST.Where(x => x.ID == model.ID).FirstOrDefault();
                        if (data == null)
                        {
                            model.CREATED_ON = DateTime.Now;
                            this.context.DEMO_MAST.Add(model);
                        }
                        else
                        {
                            model.MODIFIED_ON = DateTime.Now;
                            this.context.Entry(data).CurrentValues.SetValues(model);
                        }
                        int flg = this.context.SaveChanges();
                        return flg;
                    }
                    catch (Exception ex)
                    {
                        return 0;
                    }
                }
