    public async Task<IHttpActionResult> SendSMSNotification([FromBody] SMSNotification smsNotification)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }            
        await _service.SendSMS(smsNotification);
        return Ok();
    }
