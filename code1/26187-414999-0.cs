    from e in linq0
    let comment = new
        {
           Id = e.Id,
           CommentText = e.CommentText,
           UserId = e.UserId,
           User = (e.User.FirstName + " " + e.User.LastName).Trim()),
           Date = string.Format("{0:d}", e.Date)
        }
    orderby comment.User descending
    select comment
