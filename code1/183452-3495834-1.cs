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
                Sample d = new Sample();
                IEnumerable<MembershipUser> ll = new List<MembershipUser>()
                {
                    new MembershipUser() { Name ="1", IsApproved=false},
                    new MembershipUser() { Name ="2", IsApproved=true},
                };
    
                d.FindType(members => members.Where(m => m.IsApproved).ToList(), ll);
                Console.WriteLine(d.Users.Count());
            }
    
            class MembershipUser
            {
                public string Name
                {get;set;}
                public bool IsApproved
                {get;set;}
            }
    
            class Sample
            {
                private List<MembershipUser> users;
    
                public void FindType(Func<IEnumerable<MembershipUser>, List<MembershipUser>> filter, IEnumerable<MembershipUser> list)
                {
                    users = filter(list);
                }
    
                public List<MembershipUser> Users
                {
                    get { return users; }
                }
            }
        }
    }
