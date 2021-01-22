    // 1. CN end with "liu", Mail conatains "live" (Eg: mv@live.cn), job title is "Dev" and AD object type is user.
    // 2. CN start with "pang", Mail conatains "live" (Eg: mv@live.cn), job title is "Dev" and AD object type is user.
                IFilter filter =
                    new And(
                        new IsUser(),
                        new Contains(PersonAttributeNames.Mail, "live"),
                        new Is(PersonAttributeNames.Title, "Dev"),
                        new Or(
                                new StartWith(AttributeNames.CN, "pang"),
                                new EndWith(AttributeNames.CN, "liu")
                            )
                        );
    // Output the user object display name.
    foreach (var userObject in UserObject.FindAll(this.ADOperator, filter))
    {
        using (userObject)
        {
            Console.WriteLine(userObject.DisplayName);
        }
    }
