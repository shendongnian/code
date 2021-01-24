        public class SeederData
    {
        public static ModuleComponent[] SeederModuleArray()
        {
            int index = 1;
            var result = new List<ModuleComponent>();
            var admin = new ModuleComponent
            {
                Id = index,
                DisplayOrder = 0,
                ModuleName = "Admin",
                Level = 0
            };
            result.Add(admin);
            var dashboard = new ModuleComponent
            {
                Id = ++index,
                DisplayOrder = 1,
                ModuleName = "Dashboard",
                Level = 0
            };
            result.Add(dashboard);
            var Organisation = new ModuleComponent
            {
                Id = ++index,
                ModuleName = "Organisation",
                Level = 1,
                DisplayOrder = 0,
                ParentId = admin.Id
            };
            result.Add(Organisation);
            var Leave = new ModuleComponent
            {
                Id = ++index,
                ModuleName = "Leave",
                Level = 1,
                DisplayOrder = 3,
                ParentId = dashboard.Id
            };
            result.Add(Leave);
            return result.ToArray();
        }
    }
