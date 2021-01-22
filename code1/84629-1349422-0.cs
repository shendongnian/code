    //Create the SAML Assertion
    SamlAssertion samlAssert = new SamlAssertion();
    samlAssert.AssertionId = Convert.ToBase64String(encoding.GetBytes(System.Guid.NewGuid().ToString()));samlAssert.Issuer = "http://www.example.com/";
            
    // Set up fthe conditions of the assertion - Not Before and Not After
    Uri[] approvedAudiences = {new Uri("http://www.example2.com")};
    List<SamlCondition> conditions = new List<SamlCondition>();
    conditions.Add(new SamlAudienceRestrictionCondition(approvedAudiences));
    samlAssert.Conditions = new SamlConditions(DateTime.Now, DateTime.Now.AddMinutes(5), conditions);
