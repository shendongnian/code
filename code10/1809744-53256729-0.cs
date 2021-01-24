      var company =  from c in _context.Company
                               join f in _context.FormFamily
                               on c.Id equals f.CompanyId   
                               where c.Id == id
                               select new Company()
                               {
                                   Id = c.Id,
                                   operators = c.Operator.ToList(),
                                   formFamilies = c.FormFamily.Where(x=>x.IsActive == 
                                                   false).ToList()
                               } .FirstOrDefault();
