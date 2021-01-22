    string username = .../ retrieve username here
    Membership.CreateUser(username , password, email);
    ProfileBase newProfile = Profile.Create(username); //since the user has just been created, all properties will be blank
    //set all entered properties
    newProfile.SetPropertyValue("MyProp1", myProp1Value);
    ... 
    newProfile.SetPropertyValue("MyPropN", myPropNValue);
    newProfile.Save();
