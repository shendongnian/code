    $deserialized = Start-Job {
        Add-Type -TypeDefinition @"
        public class Parent {
            public override string ToString() { return "overriden parent"; }
            public int IntParent { get { return 1; } }
        }
        public class TestClass : Parent
        {
            public string GString() { return "this is a test string"; }
            public override string ToString() { return "overriden tostring" + System.DateTime.Now.ToString(); }
            public int IntProp { get { return 3451; } }
        }
    "@
        New-Object TestClass
    } | Wait-Job | Receive-Job
    $deserialized.ToString()
    $deserialized | gm -for
