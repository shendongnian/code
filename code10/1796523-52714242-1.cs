    public EmailContent GetEnqDetails(string EnqId)
    {
        if (!string.IsNullOrEmpty(EnqId))
        {
            var x = from n in db.Employee
                            where n.Id == EnqId
                            select new EmailContent { Subject = n.Name + " " + n.Email, Body = "get any property by typing n." };
            return x.FirstOrDefault();
        }
        else
        {
            return null;
        }
    }
