     public void UpdateLoanBal(MPAreceipting mpa, string id)
        {
            var db = new BOSAEntities();
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var lOANBAL = db.LOANBALs.Find(loanno);
                    General gn = new General();
                    gn.GetUser();
                    gn.GetServerDate();
                    LoanRepayment lr = new LoanRepayment();
                    lr.GetMemberDeduction(loanno);
                    lOANBAL.LoanNo = loanno;
                    lOANBAL.AuditID = gn.sysUser;
                    lOANBAL.AuditTime = gn.serverDate;
                    lOANBAL.Balance = Convert.ToDecimal(lr.loanBalance);
                    lOANBAL.IntrOwed = Convert.ToDecimal(lr.intOwed);
                    lOANBAL.LastDate = mpa.dateDeposited;
                    lOANBAL.TransactionNo=lr.
    
                    db.Entry(lOANBAL).State = EntityState.Modified;
                    db.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (DbEntityValidationException Exc)
                {
                    dbContextTransaction.Rollback();
                    string errormessage = string.Join(";",
                        Exc.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                    throw new DbEntityValidationException(errormessage);
                }
            }
        }
