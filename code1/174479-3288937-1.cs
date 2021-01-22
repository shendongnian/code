    var configuration = new NameValueCollection();
    configuration.Add("name", "SqlProvider");
    configuration.Add("connectionStringName", "SqlServices");
    configuration.Add("applicationName", "MyApplication");
    configuration.Add("enablePasswordRetrieval", "false");
    configuration.Add("enablePasswordReset", "true");
    configuration.Add("requiresQuestionAndAnswer", "true");
    configuration.Add("requiresUniqueEmail", "false");
    configuration.Add("passwordFormat", "Hashed");
    configuration.Add("maxInvalidPasswordAttempts", "5");
    configuration.Add("passwordAttemptWindow=", "10");
    var provider = new SqlMembershipProvider();
    provider.Initialize("SqlProvider", configuration);
    // And here store it in a static field or register it with your
    // favorite IoC container.
    container.RegisterSingle<MembershipProvider>(provider);
