    public class register_email_job_map : ClassMap<register_email_job>
    {
        public register_email_job_map()
        {
            Id( x => x.Id );
            References( x=> x.user );
        }
    }
    
    public class user_comment_map : ClassMap<user_comment>
    {
        public register_email_job_map()
        {
            // properties from BaseComment2
            References( x=> x.user );
            References( x=> x.parent );
        }
    }
