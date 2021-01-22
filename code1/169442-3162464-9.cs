    public class CommenterBadge : BadgeJob
    {
        public CommenterBadge() : base() { }
        protected override void AwardBadges()
        {
            //select all users who have more than x comments 
            //and dont have the commenter badge
            //add badges
        }
        //run every 10 minutes
        protected override TimeSpan Interval
        {
            get { return new TimeSpan(0,10,0); }
        }
    }
