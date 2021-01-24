    class DummyResponse : HttpResponseMessage {
        public DummyResponse(HttpStatusCode statusCode) : base(statusCode) {
        }
        protected override void Dispose(bool disposing) {
            Console.WriteLine("dispose called");
            base.Dispose(disposing);
        }
    }
