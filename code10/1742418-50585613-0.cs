    public class MediaController : TrsBaseController
    {
    
        public MediaController(MyDbContext context)
            : base(context)
        {
    
        }
    
        //// GET: api/media
        [HttpGet]
        public async Task<IEnumerable<MediumViewModel >> GetMedia()
        {
            var result = await this.Context.Medium.ToListAsync();
            return result.Select(x=> new MediumViewModel {Medium = x.MediumID, Solution  = x.SolutionID}); // and so on
        }
    }
