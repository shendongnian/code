    [WebMethod]
        public void BroadcastMessage(string Message)
        {
            //MessageBus.GetInstance().SendAll("<span class='system'>Web Service Broadcast: <b>" + Message + "</b></span>");
            //return;
            InvokeMethod("BroadcastMessage", new Dictionary<string, object>() { {"Message", Message} });
        }
    
        [RequiresPermission("editUser")]
        void _BroadcastMessage(string Message)
        {
            MessageBus.GetInstance().SendAll("<span class='system'>Web Service Broadcast: <b>" + Message + "</b></span>");
            return;
        }
