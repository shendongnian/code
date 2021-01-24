    public void PaidOrder(string paymentCode)
    {
        using (MyEntities db = new MyEntities())
        {
            using (DbContextTransaction trans = db.Database.BeginTransaction())
            {
                db.GetAppLock("PaidOrder");
                Order_Payment_Code payment = db.Order_Payment_Code.Where(item => item.PaymentCode == paymentCode).FirstOrDefault();
                if(payment.Status == PaymentStatus.NotPaid)
                {
                    //This Scope can be executed multiple times
                    payment.Status = PaymentStatus.Paid;
                    db.Entry(payment).State = EntityState.Modified;
                    db.SaveChanges();
    
                    //Continue processing Order
    
                }
                trans.Commit();
            }
        }
    }
