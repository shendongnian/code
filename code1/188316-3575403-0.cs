    BusinessObject obj = new BusinessObject();
    // populate fields
    BusinessObjectValidator objValidator = obj.GetValidator();
    if (objValidator.IsValid) {
        obj.Save();
    } else {
        foreach (var errorMessage in objValidator.ErrorMessages) {
            // output message
        }
    }
