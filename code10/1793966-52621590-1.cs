    switch (switch (currentUser.Role)
    {
        case "Admin": 
            // nothing to do
            break;
        case "Publisher":
            initialQuery =  initialQuery
                .Where(joinResult => joinResult.Book.Publisher == currentUser.PublisherId);
            break;
        default: 
            throw new UnauthorizedAccessException();
    } 
