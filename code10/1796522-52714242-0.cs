    public EmailContent GetEnqDetails(string EnqId)
    {
        if (EnqId != null)
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
