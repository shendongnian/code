    FieldInfo transport = smtpClient.GetType().GetField("transport", BindingFlags.NonPublic | BindingFlags.Instance);
    FieldInfo authModules = transport.GetValue(smtpClient).GetType().GetField("authenticationModules",BindingFlags.NonPublic | BindingFlags.Instance);
    Array modulesArray = authModules.GetValue(transport.GetValue(smtpClient)) as Array;
    foreach (var module in modulesArray)
    {
        Console.WriteLine(module.ToString());
    }
    // System.Net.Mail.SmtpNegotiateAuthenticationModule
    // System.Net.Mail.SmtpNtlmAuthenticationModule
    // System.Net.Mail.SmtpDigestAuthenticationModule
    // System.Net.Mail.SmtpLoginAuthenticationModule
    // overwrite the protocols that you don't want
    modulesArray.SetValue(modulesArray.GetValue(3), 0);
    modulesArray.SetValue(modulesArray.GetValue(3), 1);
    modulesArray.SetValue(modulesArray.GetValue(3), 2);
