    public class dbService
    {
        private databaseDataContext db = new databaseDataContext();
        public IQueryable<vwPostsInfo> AllPostsAndDetails()
        {
            return db.vwPostsInfos;
        }
        public IQueryable<role> GetUserRoles(int userID)
        {
            return (from r in db.roles
                        join ur in db.UsersRoles on r.rolesID equals ur.rolesID
                        where ur.userID == userID
                        select r);
        }
        public IEnumerable<user> GetUserId(string userName)
        {
            return db.users.Where(u => u.username.ToLower() == userName.ToLower());
        }
        public bool logOn(string username, string password)
        {
            try
            {
                var userID = GetUserId(username);
                var rolesIQueryable = GetUserRoles(Convert.ToInt32(userID.Select(x => x.userID).Single()));
                string roles = "";
                foreach (var role in rolesIQueryable)
                {
                    roles += role.rolesName + ",";
                }
                roles.Substring(0, roles.Length - 2);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                           1, // Ticket version
                           username, // Username associated with ticket
                           DateTime.Now, // Date/time issued
                           DateTime.Now.AddMinutes(30), // Date/time to expire
                           true, // "true" for a persistent user cookie
                           roles, // User-data, in this case the roles
                           FormsAuthentication.FormsCookiePath);// Path cookie valid for
                // Encrypt the cookie using the machine key for secure transport
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(
                   FormsAuthentication.FormsCookieName, // Name of auth cookie
                   hash); // Hashed ticket
                // Set the cookie's expiration time to the tickets expiration time
                if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
                // Add the cookie to the list for outgoing response
                HttpContext.Current.Response.Cookies.Add(cookie);
                return true;
            }
            catch
            {
                return (false);
            }
        }
    }
