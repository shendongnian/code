        public void LogAction<T>(T obj)
        {
        }
        public ActionResult Test([FromBody] Thing thing)
        {
            LogAction(thing);
        }
