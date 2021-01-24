    class MessageFilter : IMessageFilter
    {
        public static IntPtr MyHandle { get; set; }
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == /*windows code for resizing*/ && m.HWnd == MyHandle)
            {
                //do what you desire
                return true;
            }
            else
                return false;
        }
    }
