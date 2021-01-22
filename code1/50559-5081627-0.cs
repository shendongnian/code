    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    static class Extensions
    {
        /// <summary>
        /// Convert ArrayList to List.
        /// </summary>
        public static List<T> ToList<T>(this ArrayList arrayList)
        {
            List<T> list = new List<T>(arrayList.Count);
            foreach (T instance in arrayList)
            {
                list.Add(instance);
            }
            return list;
        }
    }
