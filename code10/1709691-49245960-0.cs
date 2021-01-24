       [HttpPatch]
        [Route("Test")]
        public IActionResult PostFakeObject([FromBody]Test test)
        {
            foreach (var modelState in ViewData.ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                  //Error details listed in var error
                }
            }
            return null;
        }
    }
