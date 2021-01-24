    using CancellationExample.Models;
    using System.Data;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Search(string name, CancellationToken cancellationToken)
        {
            CancellationToken disconnectedToken = Response.ClientDisconnectedToken;
            var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, 
                disconnectedToken);
            DataTable dt = null;
            var business = new Table1Business();
            dt = await business.Search(name, source.Token);
            return PartialView(dt.AsEnumerable().Select(x => x.Field<string>("Name")));
        }
    }
