    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        MultiRetouchesEntities db = new MultiRetouchesEntities();
        Type entityType = validationContext.ObjectInstance.GetType();
        string propertyName= validationContext.ObjectType.GetProperty(validationContext.MemberName).Name.ToLower();
        int nbOfEntities = db.Set(entityType).Where(propertyName + "=@0",((string)value).ToLower()).Count();
        return nbOfEntities == 0 ? ValidationResult.Success : new ValidationResult("Le nom choisi existe déjà !");
    }
