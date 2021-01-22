    public static OCall PopCall()
    {
        using(var tran = new TrasactionScope())
            using (var db = new MyDataContext())
            {
                var fc = (from c in db.Calls where c.Called == false select c).FirstOrDefault();
                OCall call = FillOCall(fc);
                if (fc != null)
                {
                    db.Calls.DeleteOnSubmit(fc);
                    db.SubmitChanges();
                }
                return call;
            }
            tran.Complete();
        }
    }
