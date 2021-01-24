    public class MediaController : TrsBaseController
    {
    
        public MediaController(MyDbContext context)
            : base(context)
        {
    
        }
    
        //// GET: api/media
        [HttpGet]
        public IEnumerable<MediumViewModel> GetMedia()
        {
            var result = this.Context.Medium.ToList();
            return result.Select(x=> new MediumViewModel {Medium = x.MediumID, Solution  = x.SolutionID}); // and so on
        }
    }
    public class MediumViewModel
    {
        public long Medium { get; set; }
    
        public long Solution { get; set; }
    }
