    string tokenTemplateString = "{{Paste here the XML that you got at step 10 (Restriction Requirements)}}";
    TokenRestrictionTemplate tokenTemplate =
                TokenRestrictionTemplateSerializer.Deserialize(tokenTemplateString);                                                                                                                                                  
    string testToken = TokenRestrictionTemplateSerializer.GenerateTestToken(tokenTemplate, tokenTemplate.PrimaryVerificationKey, new Guid("Paste here the ID that you got at step 10. Remove the "nb:kid:UUID:" part!"), DateTime.Now.AddHours(10));
    Console.WriteLine("The authorization token is:\nBearer {0}", testToken);
