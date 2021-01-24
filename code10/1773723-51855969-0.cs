            [HttpPost]
        public object Post([FromBody]List<JitCollect> jsonPost)
        {
            var resul = jsonPost.FirstOrDefault().Timestamp.Value.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK");
            return new List<JitCollect>() {
                new JitCollect{ ProjectId = 1, Jit = "J1", Timestamp = DateTime.Now }
            };
        }
