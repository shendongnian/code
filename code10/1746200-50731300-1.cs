    // The component to add
    public class B : MonoBehaviour
    {
        public void TestCall()
        {
            Debug.Log("Success");
        }
    }
    public class A : MonoBehaviour
    {
        public string ToAddName = "B";
    
        private void Start()
        {
            System.Type t = System.Type.GetType(ToAddName);
            AddComponent(t);    // This does successfully add the component (assuming it exists)
    
            Debug.Log(t.GetType());    // This will give out "System.MonoType"
    
            // This doesn't work since it is not known that this is actually "B", not "MonoScript"
            GetComponent(t).TestCall();
    
            // What is possible is this, requires hardcoding the method name though:
            System.Reflection.MethodInfo mI = t.GetMethod("TestCall");
            var c = GetComponent(t);
            mI.Invoke(c, null);    // null because "TestCall" doesn't take params
        }
    }
