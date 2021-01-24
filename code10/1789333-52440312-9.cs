    public class ColorContext : ModelValidBase
    {
        public ColorContext(ValidationContext v, object p) : base(v, p)
        {
        }
        public override ValidationResult Dosomthing()
        {
            Color vehicule = (Color)_validContext;
            //Do something with db.Color, for exemple
            db.Color.Add(Color);
            return ValidationResult.Success;
        }
    }
