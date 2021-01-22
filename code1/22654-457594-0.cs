    public class Connect : IDTExtensibility2, IDTCommandTarget
    {
        public void OnConnection( object application, ext_ConnectMode connectMode, object addInInst, ref Array custom )
        {
            _applicationObject = ( DTE2 ) application;
            _applicationObject.Events.SelectionEvents.OnChange += SelectionEvents_OnChange;
        }
        void SelectionEvents_OnChange()
        {
            vsWindowType type = _applicationObject.ActiveWindow.Type;
            // switch (type) { ... }
        }
    }
