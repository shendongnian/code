        [HttpPost]
        public IActionResult Post([FromBody] byte[] rawData)
        {
            try
            {
                System.Diagnostics.Trace.WriteLine("Total bytes posted: " + rawData?.Length);
                return StatusCode(200);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Error. msg: {ex.Message}");
            }
        }
