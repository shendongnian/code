    public class MyButton : Button
    {
        [Editor("AssemblyReferenceCL.MyEditor, AssemblyReferenceCL", typeof(UITypeEditor))]
        public String MyProp { get; set; }
    }
