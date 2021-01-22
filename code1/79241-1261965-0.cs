        public delegate void MethodInvoker();
        void ping_EventPingDone(object sender, QueryStatisticInformation info)
        {
            if (UIThread != null)
            {
                Dispatcher.FromThread(UIThread).Invoke((MethodInvoker)delegate
                {
                    queriesViewModel.AddQuery(info);
                }
                , null);
            }
            else
            {
                queriesViewModel.AddQuery(info);
            } 
        }
