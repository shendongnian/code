    PS> scriptcs
    scriptcs (ctrl-c to exit or :help for help)
    
    > public class SomeClass {}
    > public class SomeClassB : SomeClass {}
    > public class Test<T> where T: SomeClass
    * {
    *     public Dictionary<T, KeyValuePair<int, bool>> gridContent = new Dictionary<T, KeyValuePair<int, bool>>();
    * }
    >
    > var testInstance = new Test<SomeClassB>();
    > // casting error
    > // var testGridContent = (Dictionary<SomeClass, KeyValuePair<int, bool>>)testInstance.gridContent;
    >
    > var testGridContent = testInstance.gridContent.ToDictionary(kvp=>(SomeClass)kvp.Key, kvp=>kvp.Value);
