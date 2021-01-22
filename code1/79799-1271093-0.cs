    using ...;
    namespace SomeCOMTool
    {
        [ClassInterface(ClassInterfaceType.AutoDual)]
        [ProgId("MyCOMTool")]
        [ComVisible(true)]
        [Guid("your-guid-here without curly brackets!")]
        public class MyCOMTool
        {
            /// <summary>
            /// Empty constructor used by Navision to create a new instance of the control.
            /// </summary>
            public MyCOMTool()
            {
            }
 
            [DispId(101)]
            public bool DoSomething(string input, ref string output)
            {
            }
        }
    }
