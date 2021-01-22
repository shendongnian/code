    class MyClient : TcpClient {
        public bool IsDead { get; set; }
        protected override void Dispose(bool disposing) {
            IsDead = true;
            base.Dispose(disposing);
        }
    }
