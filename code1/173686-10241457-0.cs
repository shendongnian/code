    Residents resident = new Residents()
       {
           IsNewResident = true,
           ResidentImage = Settings.Default.ResidentCardDefaultMaleImage,
           IsActive = true,
           ResidentCanBeDeleted = true,
           ResidentMasterDataState = EvoState.Error,
           ResidentBasicDataState = EvoState.Error,
           ResidentBenefactorsDataState = EvoState.Error,
       };
    //Now you need to either initialize a residentextextensions entity
    // with proper values, or just do not relate it with the resident entity.
    ResidentExtensions temp = new ResidentExtensions();
    temp.PropertyA = 3;
    //etc.
    resident.ResidentExtensions = temp;
