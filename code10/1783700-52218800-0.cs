        using Outlook = Microsoft.Office.Interop.Outlook;
    object oMissing = System.Reflection.Missing.Value;
    
    // create outlook object
    Outlook.Application otApp = new Outlook.Application();
    
    string[] functionParameters =
                { 
                    sTo,
                    sCC,
                    sBCC,
                    sSubject,
                    sBody
                };
    
    // Run the macro
    otApp.GetType().InvokeMember("YourVBA",
                System.Reflection.BindingFlags.Default |
                System.Reflection.BindingFlags.InvokeMethod,
                null, otApp, functionParameters);
