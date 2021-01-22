    private bool IsvalidUser(string userName, string password)
            {
                DataClasses1DataContext context = new DataClasses1DataContext();
                var query = from p in context.EMP
                            where p.EUSERNAME == userName
                            && p.EPassword == password
                            select p;
    
                if (query.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
