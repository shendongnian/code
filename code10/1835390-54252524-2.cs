    public class TiketsController : ControllerBase
    {
        private readonly MCContext _context;
        public TiketsController (MCContext context)
        {
            _context = context;
        }
     }
