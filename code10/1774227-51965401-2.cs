    public virtual IActionResult Method([FromBody]GridDataObject data) {
        if(ModelState.IsValid) { 
            //...
            var gridData = data.gridData;
            //...
            return Ok();
        }
        return BadRequest();
    }
    
