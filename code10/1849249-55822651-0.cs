using System;
using System.Linq;
using MongoDAL;
namespace AdminActs
{
    class Admin : Entity
    {
        public DailyActivity[] DailyActivities { get; set; }
    }
    class DailyActivity
    {
        public DateTime Time { get; set; }
        public SubActivity[] SubActivities { get; set; }
    }
    class SubActivity
    {
        public DateTime EntryDate { get; set; }
        public string Category { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DB("activities");
            var now = DateTime.Now;
            var admin = new Admin
            {
                DailyActivities = new DailyActivity[]
                {
                    new DailyActivity{
                        Time = now,
                        SubActivities = new SubActivity[]
                        {
                            new SubActivity{
                                Category ="Power Consumption",
                                EntryDate = DateTime.Now}
                        }
                    }
                }
            };
            admin.Save();
            var subActivities = admin.Collection()
                                     .SelectMany(a => a.DailyActivities)
                                     .Where(da => da.Time == now)
                                     .SelectMany(da => da.SubActivities)
                                     .Where(sa => sa.Category == "Power Consumption");
            var res = subActivities.ToArray();
            Console.ReadKey();
        }
    }
}
