        public async Task<ActionResult> GetLinks1()
        {
            var result = await new Client().GetLinks1();
            return Ok(result);
        }
