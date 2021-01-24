    public class DataAccess
    {
        public int GetUserIdByUserName(string username)
        {
            using (var context = new EmployeeUsersEntities())
            {
                var user = context.Users.First(d => d.Name == username);
                return user.Id;
            }
        }
    
        public string GetSectorByUserId(int id)
        {
            using (var context = new EmployeeEntities())
            {
                var sector = context.Sectors.First(d => d.UserId == id);
                return sector.Sector_name;
            }
        }
    }
