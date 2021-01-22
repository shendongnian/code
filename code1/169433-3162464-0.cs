    public abstract class BadgeJob
    {
     protected abstract class AwardBadges();
     private void Callback(string key, object value, CacheItemRemovedReason reason)
     {
         if (reason == CacheItemRemovedReason.Expired)
         {
             AwardBadges();
             Insert();
         }
     }
     private void Insert()
     {
         HttpRuntime.Cache.Add(this.GetType().ToString(),
             this,
             null,
             Cache.NoAbsoluteExpiration,
             new TimeSpan(0, 10, 0),
             CacheItemPriority.Normal,
             this.Callback);
     }
