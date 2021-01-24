    public class UserRank
    {
        public User UserA{get;set;}
        public User UserB{get;set;}
        public int Compare{
            get{return ((UserA.A && UserB.A)?1:0)
                      +((UserA.B && UserB.B)?1:0)
                      +((UserA.C && UserB.C)?1:0)
                      +((UserA.D && UserB.D)?1:0)
                      +((UserA.E && UserB.E)?1:0);}
        }
    }
