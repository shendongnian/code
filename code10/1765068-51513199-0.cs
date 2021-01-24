      app.UseMvc(routes =>
            {
                routes.MapRoute(
                            "New",
                            "{area:exists}/{leagueName?}/{controller}/{action}/{id?}",
                            new { leagueName= "NHL", controller = "Default", action = "Index" },
                            new { leagueName= "NHL|NFL" }
                        );
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
       [Area("FantasyDraftBoard")]
       public class DefaultController : Controller
       {
        public IActionResult Index(string leagueName)
        {
            return View();
        }
       }
