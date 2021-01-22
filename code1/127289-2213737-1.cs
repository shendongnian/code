    var c = new SomeClass();
    c.SampleMethod = inputParam => inputParam.ToLower();
    c.DoSomeTaskThatReliesOnSampleMethodReturingAnUpperCaseString();
    c.SampleMethod = null;
    c.DoSomeTaskThatCallsSampleMethod(); // NullReferenceException
