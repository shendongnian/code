    public static class MyExtensions
    {
        public static IEnumerable<ITechnician> OfTypeTechnician(this IEnumerable<IDictionary<string, string>> records)
        {
            foreach (var record in records)
            {
                if (!record.TryGetValue("ServiceTech", out var serviceTech)) continue;
                if (!record.TryGetValue("ServiceTechHrs", out var serviceTechHrsStr) || !double.TryParse(serviceTechHrsStr, out var serviceTechHrs)) continue;
                yield return new Technician { ServiceTech = serviceTech, ServiceTechHours = serviceTechHrs };
            }
        }
        private class Technician : ITechnician
        {
            public string ServiceTech { get; set; }
            public double ServiceTechHours { get; set; }
        }
    }
