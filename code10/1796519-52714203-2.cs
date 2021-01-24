    public static EmailContent GetEnqDetails(int EnqId)
    {
        if (EnqId != null)
        {
            return db.Employee.Where(n => n.Id == EnqId)
                              .Select(x => new EmailContent()
                              {
                                  Subject = String.Format("{0} {1}",
                                  x.Name, x.Email),
                                  Body = ""
                              }).FirstOrDefault();
        }
        else
        {
            return null;
        }
    }
