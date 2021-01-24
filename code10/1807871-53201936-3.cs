         [Authorize(Policy = "Read")]
         [HttpPost("delete")]
         public IActionResult Delete([FromBody]Item item)
         {
              _itemService.Delete(item.Id);
              return Ok();
          }
