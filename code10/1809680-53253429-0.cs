    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int UserID = 1;
                int ViewerUserID = 2;
                DataBase db = new DataBase();
                var resutls = (from subU in db.subU
                               join subUt in db.subUT on subU.Id equals subUt.UserTypeID
                               select new { subU = subU, subUt = subUt })
                               .Where(x => ((x.subU.Id == ViewerUserID) && (x.subUt.Security > x.subU.Security)) || x.subU.Id == -1)
                               .ToList();
            }
        }
        public class DataBase
        {
            public List<Users> subU { get; set; }
            public List<UserTypes> subUT { get; set; }
        }
        public class Users
        {
            public int Id { get; set; }
            public int Security { get; set; }
        }
        public class UserTypes
        {
            public int UserTypeID { get; set; }
            public int Security { get; set; }
        }
    }
