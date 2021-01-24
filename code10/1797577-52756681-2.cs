    var user = new User();
    var context = new ValidationContext(user, serviceProvider: null, items: null);
    var results = new List<ValidationResult>();
    
    var isValid = Validator.TryValidateObject(user, context, results);
    
    if (!isValid)
    {
        foreach (var validationResult in results)
        {
            Console.WriteLine(validationResult.ErrorMessage);
        }
    }
