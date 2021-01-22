        class ScoredUser
        {
            public User User { get; set; }
            public int Score { get; set; }
        }
        public static List<User> FilterBySearchTerms(List<User> usersToFilter, string searchTerms, bool searchEmailText)
        {
            // Convert to lower case for better comparison, trim white space and then split on spaces to search for all terms
            string[] terms = searchTerms.ToLower().Trim().Split(' ');
        
            // Run a select statement to user list which converts them to
            // a scored object.
            return usersToFilter.Select(user =>
            {
                ScoredUser scoredUser = new ScoredUser()
                {
                    User = user,
                    Score = 0
                };
        
                foreach (string term in terms)
                {
                    if (searchEmailText && user.Email.ToLower().Contains(term))
                        scoredUser.Score++;
        
                    if (user.FirstName.ToLower().Contains(term))
                        scoredUser.Score++;
        
                    if (user.Surname.ToLower().Contains(term))
                        scoredUser.Score++;
        
                    // etc.
                }
        
                return scoredUser;
        
                // Select all scored users with score greater than 0, order by score and select the users.
            }).Where(su => su.Score > 0).OrderByDescending(su => su.Score).Select(su => su.User).ToList();
        }
