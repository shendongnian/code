    [HttpPut()]
    [Route("")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdatePaymentSync([FromBody] string paymentSyncJson)
    {
        if (string.IsNullOrEmpty(paymentSyncJson))
            return BadRequest();
         //hack: don't have access to models so need to send json rep
         var paymentSync = JsonConvert.DeserializeObject<PaymentSync>(paymentSyncJson);
       ....
    }
