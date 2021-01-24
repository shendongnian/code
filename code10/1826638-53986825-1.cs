    public class OidSpecimenBuilder : ISpecimenBuilder
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public OidSpecimenBuilder(int min, int max)
        {
            this.Min = min;
            this.Max = max; 
        }
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            if (pi == null)
            {
                return new NoSpecimen();
            }
            if (pi.PropertyType != typeof(long) || pi.Name != "OID")
            {
                return new NoSpecimen();
            }
            return context.Resolve(new RangedNumberRequest(typeof(long), Min, Max));
        }
    }
