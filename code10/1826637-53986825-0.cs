    public class SpecifiedBoolSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
    
            if (pi == null)
            {
                return new NoSpecimen();
            }
    
            if (pi.PropertyType != typeof(bool) || !pi.Name.EndsWith("Specified"))
            {
                return new NoSpecimen();
            }
    
            return true;
        }
    }
