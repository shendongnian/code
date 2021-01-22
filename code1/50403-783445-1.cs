    public static List<User> FilterBySearchTerms
        (List<User> usersToFilter, 
         string searchTerms,
         bool searchEmailText)
    {
        // Just split the search terms once, rather than for each user
        string[] terms = searchTerms.ToLower().Trim().Split(' ');
        
        return (from user in usersToFilter
                let lowerUser = LowerCaseUser(user)
                let matchCount = terms.Count(term => 
                                             UserMatches(lowerUser, term))
                where matchCount != 0
                orderby matchCount descending
                select user).ToList();
    }
    private static bool UserMatches(User user, string term,
                                    bool searchEmailText)
    {
        if ((searchEmailText && user.Email.Contains(term))
            || user.FirstName.Contains(term)
            || user.Surname.Contains(term)
            || user.Position.Contains(term)
            || user.Company.Contains(term)
            || user.Office.Contains(term)
            || user.Title.Contains(term))
        {
            return true;
        }
        int encodedID;
        if (int.TryParse(term, out encodedID))
        {
            User fromInvite = GetByEncodedUserInviteID(encodedID);
            // Let the compiler handle the null/non-null comparison
            if (fromInvite != null && fromInvite.ID == user.ID)
            {
                return true;
            }
        }
        return false;
    }
    
