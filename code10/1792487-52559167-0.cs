    using System.Linq.Dynamic.Core;
    
        List<UsersListViewModel> data = (from user in dbContext.Users
         select new UsersListViewModel
         {
             Id = user.Id,
             Name = user.FirstName + " " + user.LastName,
             UserName = user.UserName,
             Email = user.Email,
             PhoneNumber = user.PhoneNumber
         }).ToList();
        
         if (!(string.IsNullOrEmpty(Input.Order) && string.IsNullOrEmpty(Input.OrderDir)))
        {
            var columnName = modelStructure.FirstOrDefault(f => f.Key == Convert.ToInt32(Input.Order));
            data = data.OrderBy(columnName.Value + " " + Input.OrderDir).ToList();
        }
        
         if (!(string.IsNullOrEmpty(Input.Order) && string.IsNullOrEmpty(Input.OrderDir)))
        {
            var columnName = modelStructure.FirstOrDefault(f => f.Key == Convert.ToInt32(Input.Order));
            data = data.AsQueryable().OrderBy(x=> x.).ToList();
        }
