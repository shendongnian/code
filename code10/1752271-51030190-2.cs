    public override void RegisterArea(AreaRegistrationContext context)
    {
            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "ControlTower2Report.Areas.Administration.Controllers" }
            );
            context.MapRoute(
                "Administration_defaultWithCulture",
                "{culture}/Administration/{controller}/{action}/{id}",
                new { culture = "en", action = "Index", id = UrlParameter.Optional },
                constraints: new { culture = new CultureConstraint(defaultCulture: "en", pattern: "[a-z]{2}") },
                namespaces: new string[] { "ControlTower2Report.Areas.Administration.Controllers" }
          );
    }
