    /* Externally Accesssible Event API */
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ISerialEvent
    {
        [DispId(5)]
        void dEvent();
    }
