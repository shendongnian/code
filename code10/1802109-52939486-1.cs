            public void ResetId()
        {
             try
            {
                using (DaghanKantarEntities context = new DaghanKantarEntities())
                {
                    context.Database.ExecuteSqlCommand("DELETE FROM dbo.tbl_MainWeight");
                    context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('tbl_MainWeight', RESEED, 0)");
                    context.SaveChanges();
                }
            }
            catch (Exception exp)
            {
                throw new Exception("Hata: Kayıt Resetlenemedi - " + exp.Message.ToString(), exp);
            }
        }
