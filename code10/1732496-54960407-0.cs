    [HttpPatch("{id}")]
    public IActionResult Patch(int id, [FromBody]JsonPatchDocument<Node> value)
    {
        try
        {
            //nodes collection is an in memory list of nodes for this example
            var result = nodes.FirstOrDefault(n => n.Id == id);
            if (result == null)
            {
                return BadRequest();
            }    
            value.ApplyTo(result, ModelState);//result gets the values from the patch request
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
