    using System;
    
    namespace IdentityServer3.Core.Extensions
    {
        internal static class DateTimeOffsetHelper
        {
            internal static Func<DateTimeOffset> UtcNowFunc = () => DateTimeOffset.UtcNow;
    
            internal static DateTimeOffset UtcNow
            {
                get
                {
                    return UtcNowFunc();
                }
            }
            internal static int GetLifetimeInSeconds(this DateTimeOffset creationTime)
            {
                return (int)(UtcNow - creationTime).TotalSeconds;
            }
        }
    }
