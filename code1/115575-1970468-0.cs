     public int Add(Report obj)
            {
                //set the flush mode to Never so that session.save() does not cause a flush until the commit() 
                //on transaction is called
                _session.FlushMode = FlushMode.Never;
                using (ITransaction tx = _session.BeginTransaction())
                {
                    try
                    {
                        int newId = (int)_session.Save(obj);
                        tx.Commit();//this will cause the a flush of the session
                        return newId;
                    }
                    catch (HibernateException)
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
