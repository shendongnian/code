    ClassTemplate t = new ClassTemplate();
    t.Session = new Dictionary<string, object>();
    t.Session["ClassName"] = "Person";
    
    t.Initialize();//This is important.
    string output = t.TransformText();
    Console.WriteLine(output);
