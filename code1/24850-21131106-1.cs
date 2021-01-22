    public class LicenseTypeEnumService
        {
    
            public static Dictionary<int, string> GetAll()
            {
    
                var licenseTypes = new Dictionary<int, string>();
    
                licenseTypes.Add((int)LicenseType.xxx, "xxx");
                licenseTypes.Add((int)LicenseType.yyy, "yyy");
    
                return licenseTypes;
    
            }
    
            public static string GetById(int id)
            {
    
                var q = (from p in this.GetAll() where p.Key == id select p).Single();
                return q.Value;
    
            }
    
        }
