    var c = new SomeClass();
    c.SampleMethod = inputParam => inputParam.ToLower();
    c.DoSomeTaskThatReliesOnSampleMethodReturningAnUpperCaseString();
    c.SampleMethod = null;
    c.DoSomeTaskThatCallsSampleMethod(); // NullReferenceException
