       [ComVisible(true),
            Guid(Constants.CLASS_IID),
            ProgId(Constants.PROG_ID),
            ClassInterface(ClassInterfaceType.None),
            ComSourceInterfaces(typeof(IMyServiceEvents))]
        public class MyClass : Control, IMyService, IMyServiceEvents
        {
           [ComVisible(false)]
           public delegate void MyEventHandler(int Status);
    
           [DispId(1)]
           public event MyEventHandler MyEvent;
    
    
    
           //... also implements IMyService, which is working
        }
    
        [ComVisible(true),
            InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
            Guid(Constants.EVENTS_IID)]
        public interface IMyServiceEvents
        {
            [PreserveSig, DispId(1)]
            void MyEvent([In]int Status);
        }
