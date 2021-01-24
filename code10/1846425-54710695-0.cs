        [HTTPPost]
        [Route("MyAction/{userID:minlength(2)}/{anotherID:int}/myInfo")]
        public IActionResult MyAction(string userID, int anotherID, [FromBody]  string stuffIWant)
        {
            return Ok();
        }
    }
