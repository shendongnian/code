        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SomeType data)
        {
            // TODO: Modify data
            // Invalidate tag
            var tag = $"{controllerName}.{methodName}"
            _tagProvider.InvalidateETag(tag);
            return NoContent();
        }
