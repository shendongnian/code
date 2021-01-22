    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    
    namespace Insert.Your.Namespace.Here.Helpers
    {
        public static class Extensions
        {
            public static bool IsNullOrEmpty<T>(this IEnumerable<T> iEnumerable)
            {
                // Cheers to Joel Mueller for the bugfix. Was .Count(), now it's .Any()
                return iEnumerable == null ||
                       iEnumerable.Any() <= 0;
            }
    
            public static IList<T> ToListIfNotNullOrEmpty<T>(this IList<T> iList)
            {
                return iList.IsNullOrEmpty() ? null : iList;
            }
    
            public static PagedList<T> ToPagedListIfNotNullOrEmpty<T>(this PagedList<T> pagedList)
            {
                return pagedList.IsNullOrEmpty() ? null : pagedList;
            }
    
            public static string ToPluralString(this int value)
            {
                return value == 1 ? string.Empty : "s";
            }
    
            public static string ToReadableTime(this DateTime value)
            {
                TimeSpan span = DateTime.Now.Subtract(value);
                const string plural = "s";
    
    
                if (span.Days > 7)
                {
                    return value.ToShortDateString();
                }
    
                switch (span.Days)
                {
                    case 0:
                        switch (span.Hours)
                        {
                            case 0:
                                if (span.Minutes == 0)
                                {
                                    return span.Seconds <= 0
                                               ? "now"
                                               : string.Format("{0} second{1} ago",
                                                               span.Seconds,
                                                               span.Seconds != 1 ? plural : string.Empty);
                                }
                                return string.Format("{0} minute{1} ago",
                                                     span.Minutes,
                                                     span.Minutes != 1 ? plural : string.Empty);
                            default:
                                return string.Format("{0} hour{1} ago",
                                                     span.Hours,
                                                     span.Hours != 1 ? plural : string.Empty);
                        }
                    default:
                        return string.Format("{0} day{1} ago",
                                             span.Days,
                                             span.Days != 1 ? plural : string.Empty);
                }
            }
    
            public static string ToShortGuidString(this Guid value)
            {
                return Convert.ToBase64String(value.ToByteArray())
                    .Replace("/", "_")
                    .Replace("+", "-")
                    .Substring(0, 22);
            }
    
            public static Guid FromShortGuidString(this string value)
            {
                return new Guid(Convert.FromBase64String(value.Replace("_", "/")
                                                             .Replace("-", "+") + "=="));
            }
    
            public static string ToStringMaximumLength(this string value, int maximumLength)
            {
                return ToStringMaximumLength(value, maximumLength, "...");
            }
    
            public static string ToStringMaximumLength(this string value, int maximumLength, string postFixText)
            {
                if (string.IsNullOrEmpty(postFixText))
                {
                    throw new ArgumentNullException("postFixText");
                }
    
                return value.Length > maximumLength
                           ? string.Format(CultureInfo.InvariantCulture,
                                           "{0}{1}",
                                           value.Substring(0, maximumLength - postFixText.Length),
                                           postFixText)
                           :
                               value;
            }
    
            public static string SlugDecode(this string value)
            {
                return value.Replace("_", " ");
            }
    
            public static string SlugEncode(this string value)
            {
                return value.Replace(" ", "_");
            }
        }
    }
