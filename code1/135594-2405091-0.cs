    public static User Find(User match, string orderBy = "")
        {
            string query = "";
            if (!String.IsNullOrEmpty(match.FirstName)) query += "first_name='" + match.FirstName + "'";
            if (!String.IsNullOrEmpty(match.LastName)) query += "last_name='" + match.LastName+ "'";
            return Find(query + (!String.IsNullOrEmpty(orderBy) ? orderBy : ""));
        }
