     public class OzoneLiveLite : Ozone_Live_LiteEntities
    {
        public DbSet<CORP_MASTER> CorpMaster { get; set; }
        public DbSet<JCS_FINYEAR> JcsFinyear { get; set; }
        public DbSet<JCS_JOB> JcsJob { get; set; }
        public DbSet<JCS_JOB__JCS_JOB_SUBJOB> JcsJobJcsJobSubjob { get; set; }
        public DbSet<JCS_FINYEAR__JCFY_PERIOD> JcsFinyearJcfyPeriod { get; set; }
    }
