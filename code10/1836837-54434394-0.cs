    public class YourScriptName : Monobehaviour
    {
        public class CBObj
        {
            public int data1;
            public float data2;
        }
    
        public void MethodName(string data)
        {
             var obj = UnityEngine.JsonUtility.FromJson<CBObj>(data);
        }
    }
