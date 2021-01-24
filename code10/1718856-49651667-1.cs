    var query = (from s in Suppliers 
                 select new 
                 {
                     SupplierId = s.SupplierId,
                     CompanyName = s.CompanyName,
                     ContactPerson = s.ContactPerson,
                     Address = s.Address,
                     Email = s.Email,
                     InActive = s.InActive,
                     BranchId = s.BranchId,
                     CreateDate = s.CreateDate,
                     CreatedBy = s.CreatedBy,
                     UpdateDate = s.UpdateDate,
                     UpdateBy = s.UpdatedBy,
                     PhoneNumber = s.PhoneNumber,
                     Balance = SupplierTransactions
                              .Where(st => st.SupplierId == s.SupplierId)
                              .Select(st => (st.CreditAmount - st.DebitAmount))
                              .Sum()
                 });
