    public class SongsController : Controller
    {
        private const string FieldAccess = "ID,Title,Author,Genre,Level";
    
        public ActionResult Create([Bind(Include = FieldAccess)] Song song)
        {
    
        }
    }
