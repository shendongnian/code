    class TextBoxSynchronizedScroll : TextBox
    {
        public const int WM_VSCROLL = 0x115;
        List<TextBoxSynchronizedScroll> peers = new List<TextBoxSynchronizedScroll>();
        public void AddPeer(TextBoxSynchronizedScroll peer)
        {
            this.peers.Add(peer);
        }
        private void DirectWndProc(ref Message m)
        {
            base.WndProc(ref m);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_VSCROLL)
            {
                foreach (var peer in this.peers)
                {
                    var peerMessage = Message.Create(peer.Handle, m.Msg, m.WParam, m.LParam);
                    peer.DirectWndProc(ref peerMessage);
                }
            }
            base.WndProc(ref m);
        }
    }
