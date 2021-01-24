        public partial class SubJobDetails
    {
        public static SubJobDetails GetSubjobsAndParts(string mReq, CustomerEntities db)
        {
            var Parts = from pts in db.PartsView
                        join sj in db.SubJobs on pts.SubJob equals sj.SubJob
                        join tlj in db.TopLvlJobs on sj.TopLvlJob equals tlj.TopLvlJob
                        where (pts.SubJob == mReq)
                       select new SubJobDetails()
                       {
                           PartsView = pts,
                           TopLvlJob = tlj.TopLvlJob,
                           SubJobs = sj,
                       };
            var result = Parts.FirstOrDefault();
            if (result != null)
            {
                result.PartsDetail = db.PartsView.Where(a => a.SubJob == result.PartsView.SubJob);
            };
            return result;
        }
        public string TopLvlJob { get; set; }
        public virtual TopLvlJobs TopLvlJobs { get; set; }
        public virtual PartsView PartsView { get; set; }
        public virtual SubJobs SubJobs { get; set; }
        public virtual IEnumerable<PartsView> PartsDetail { get; set; }
    }
