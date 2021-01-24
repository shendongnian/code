    public class VehiculeContext : ModelValidBase
    {
        public VehiculeContext(ValidationContext v, object p) : base(v, p)
        {
        }
        public override ValidationResult Dosomthing()
        {
            MultiRetouchesEntities db = new MultiRetouchesEntities();
            Vehicule vehicule = (Vehicule)(_validContext.ObjectInstance) ;
            bool validateName = db.Vehicule.Any(x => x.Name == (string)parameterValue);
            if (validateName == true)
            {
                return new ValidationResult("This vehicule already exists", new string[] { "Name" });
            }
            return ValidationResult.Success;
        }
    }
