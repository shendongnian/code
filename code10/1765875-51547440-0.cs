        private ConcurrentDictionary<Guid, ManualResetEvent> _waitingClients = new ConcurrentDictionary<Guid, ManualResetEvent>();
        private ConcurrentDictionary<Guid, byte[]> _hostResponses = new ConcurrentDictionary<Guid, byte[]>();
        public TEventResult SendCommand<TEventResult>(ICommand cmd)
        {
            var mre = new ManualResetEvent(false);
            var s = _serialize(cmd);
            if(_waitingClients.TryAdd(cmd.Ticket, mre))
            {
                if (!_sendDownPipe(s))
                {
                    _waitingClients.TryRemove(cmd.Ticket, out mre);
                    throw new Exception("Could not get Response");
                }
            }
            mre.WaitOne();//todo timeout
            byte[] resp;
            if(_hostResponses.TryRemove(cmd.Ticket, out resp))
            {
                var o = _deserialize<TEventResult>(resp);
                return o;
            }
            throw new Exception("Could not get response!");
        }
        private void _eventRecieved(byte[] s)
        {
            var evt = _deserialize<IEvent>(s);
            if(_hostResponses.TryAdd(evt.Ticket, s))
            {
                ManualResetEvent mre;
                if(_waitingClients.TryRemove(evt.Ticket, out mre))
                {
                    mre.Set();
                }
            }
        }
