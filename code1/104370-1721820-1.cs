    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class StringDistanceUtil {
        
        /// <summary>
        ///   Returns the longest common substring of the given two arguments.
        /// </summary>
        /// <param name="first">
        ///   the first string
        /// </param>
        /// <param name="second">
        ///   the second string
        /// </param>
        /// <returns>
        ///   the longest common substring of the given two arguments
        /// </returns>
        public static string LongestCommonSubstringWith(this string first, string second) {
            // could have used dynamic programming, or generalized suffix tree
            // to solve the LCS problem, but here we'll just stick to simplicity
            
            var start = 0; // The start in a of the longest found so far
            var len = 0;   // The length of the longest found so far
            for (var i = 0; i < first.Length - len; ++i) {
                for (var j = first.Length - i; j > len; --j) {
                    if (second.Contains(first.Substring(i, j))) {
                        start = i;
                        len = j;
                        break; // Exit the inner loop
                    }
                }
            }
    
            return first.Substring(start, len);
        }
        
        /// <summary>
        ///   Returns the distance of two strings.
        /// </summary>
        /// <param name="str">
        ///   a string
        /// </param>
        /// <param name="target">
        ///   the target string
        /// </param>
        /// <returns>
        ///   the distance from a string to the target string
        /// </returns>
        public static double DistanceFrom(this string str, string target) {
            var strLen = str.Length;
            var targetLen = target.Length;
            var ratio = str.LongestCommonSubstringWith(target).Length
                    / (double) targetLen;
            var penalty =
                (strLen > targetLen) ?
                    (0.1 * (strLen - targetLen))
                    : 0;
            return ratio - penalty;
        }
        
        static void Main(string[] args) {
            var list = new List<string> {
                "zero",
                "range",
                "shot",
                "shoot",
                "hop",
                "rage",
                "fang",
                "age"
            };
            var target = "zero_range_shot";
            var top5mostRelated = list
                .OrderByDescending(str => str.ToUpper().DistanceFrom(target.ToUpper()))
                .Take(5).ToList();
            foreach (var str in top5mostRelated) Console.WriteLine(str);
        }
    }
