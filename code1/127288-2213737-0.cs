    var c = new SomeClass();
    c.SampleMethod = inputParam => inputParam.ToLower();
    c.DoSomeTaskThatReliedOnSampleMethodReturingAnUpperCaseString();
    c.SampleMethod = null;
    c.DoSomeTaksThatCallsSampleMethod(); // NullReferenceException
