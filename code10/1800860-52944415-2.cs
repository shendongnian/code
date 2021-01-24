        /// <summary>
        /// My summary
        /// </summary>
        /// <remarks>My remarks</remarks>
        /// <param name="value">value</param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Data not valid</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public void Post([FromBody] string value)
        {
        }
