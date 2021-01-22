    dynamic oWord = //ComAutomationFactory.CreateObject("Word.Application");
         Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application", true)); 
    
    oWord.Visible = false;
    
    object oTemplatePath = "c:\\vishal.dotx";
    dynamic oWordDoc = oWord.Documents.Add(ref oTemplatePath);
    dynamic fields = oWordDoc.Fields;
    
    Console.WriteLine("template has {0} merge flds", fields.Count);
    
    //Method 1
    Console.WriteLine(string.Join("\n", ((IEnumerable)oWordDoc.Fields).Cast<dynamic>().Select(x=>(string)x.Result.Text).ToArray()));
    
    //Method 2
    foreach (dynamic fld in fields)
     Console.WriteLine(fld.Result.Text);
