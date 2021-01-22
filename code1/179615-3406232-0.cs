    using System;
    using System.Linq;
    static class SqlStyleExtensions
    {
        public static bool In(this string me, params string[] set)
        {
           return set.Contains(me);
        }
    }
    Usage:
    if (Variable.In("AC", "BC", "EA"))
    {
    } 
