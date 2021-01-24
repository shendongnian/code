        private static void RegistrarAreaEntidades()
        {
            string[] newAreaStrings = new string
                [] { "~/Areas.Entidades/{2}/Views/{1}/{0}.cshtml" };
            var razorEngine = ViewEngines.Engines.OfType<RazorViewEngine>().First();
            razorEngine.AreaMasterLocationFormats =
                razorEngine.AreaMasterLocationFormats.Concat(newAreaStrings).ToArray();
            razorEngine.AreaViewLocationFormats =
                razorEngine.AreaViewLocationFormats.Concat(newAreaStrings).ToArray();
        }
