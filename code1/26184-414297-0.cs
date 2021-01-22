    from e in linq0
    order by (e.User.FirstName + " " + e.User.LastName).Trim()) descending 
    select new
    {
       Id = e.Id,
       CommentText = e.CommentText,
       UserId = e.UserId,
       User = (e.User.FirstName + " " + e.User.LastName).Trim()),
       Date = string.Format("{0:d}", e.Date)
    }
