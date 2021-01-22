    public abstract class BadgeJob
    {
        protected BadgeJob()
        {
            //start cycling on initialization
            Insert();
        }
        //override to provide specific badge logic
        protected abstract void AwardBadges();
        //how long to wait between iterations
        protected abstract TimeSpan Interval { get; }
        private void Callback(string key, object value, CacheItemRemovedReason reason)
        {
            if (reason == CacheItemRemovedReason.Expired)
            {
                this.AwardBadges();
                this.Insert();
            }
        }
        private void Insert()
        {
            HttpRuntime.Cache.Add(this.GetType().ToString(),
                this,
                null,
                Cache.NoAbsoluteExpiration,
                this.Interval,
                CacheItemPriority.Normal,
                this.Callback);
        }
    }
