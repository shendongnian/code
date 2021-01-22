    // Should be cahced for further use 
    var testClassProps = CreatePropertyDelagates(typeof(TestClass));
    
    var obj = new TestClass();
                    foreach (var p in testClassProps)
                    {
                        var propValue = p.Getter(obj);
                        p.Setter(obj,propValue);
                    }
