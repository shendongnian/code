     [HttpDelete("DeleteAddress")]
            public async Task<IActionResult> DeleteAddress([FromQuery] long AddressID)
            {
                try
                {
                    long userID = this.User.GetUserID();
                    await _addressService.Delete(userID, AddressID);
                    return Ok();
                }
                catch (Exception err)
                {
                    return Conflict(err.Message);
                }
    
            }
