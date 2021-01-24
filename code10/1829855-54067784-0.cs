        [HttpGet]
        public IActionResult Setup([FromHeader] string uuid)
        {
            InitialiseStuff(uuid); //This takes several seconds to execute
            return StatusCode(200);
        }
        public Task InitialiseStuff(string uuid)
        {
            Task.Factory.StartNew(() => {
                Thread.Sleep(TimeSpan.FromSeconds(10));
                Debug.WriteLine(uuid);
            });
            return Task.CompletedTask;
        }
