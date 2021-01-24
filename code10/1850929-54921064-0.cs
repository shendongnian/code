    BindingSource bindingSource1 = new BindingSource();
    
    bindingSource1.DataSource = (from l in db.LoanItems.Where(item => item.Item.LoanItems.Any())
                                             from p in db.People.Where(person => person.Id == l.Loan.PersonId)
                                             orderby l.LoanId ascending
                                             select new
                                             {
                                                 p.Id,
                                                 p.FirstName,
                                                 l.LoanId,
                                                 l.Item.ItemId,
                                                 Dagenoud = SqlFunctions.DateDiff("Weekday", l.Loan.StartDate, DateTime.Now),
                                                 l.QuantityLoaned
                                             }).ToList();
    
    
                dataGridView1.DataSource = bindingSource1;
