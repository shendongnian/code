    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Staff
    {
        public int StaffId;
    }
    
    public static class Extensions
    {
        public static void RemoveWhere<T>(this ICollection<T> Coll,
                                          Func<T, bool> Criteria)
        {
            List<T> forRemoval = Coll.Where(Criteria).ToList();
       
            foreach (T obj in forRemoval)
            {
                Coll.Remove(obj);
            }
        }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            List<Staff> mockStaff = new List<Staff>
            {
                new Staff { StaffId = 3 },
                new Staff { StaffId = 7 }
            };
    
           Staff newStaff = new Staff{StaffId = 5};
           mockStaff.Add(newStaff);
           mockStaff.RemoveWhere(s => s.StaffId == 5);
    
           Console.WriteLine(mockStaff.Count);
        }
    }
