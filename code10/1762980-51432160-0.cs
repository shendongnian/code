    [HttpPost]
    public IActionResult CreateSalesRecord([FromBody]dynamic salesRecord)
    {
        return Ok(new SalesRecord
        {
            FirstName = salesRecord.user.name.first,
            LastName = salesRecord.user.name.Last,
            PaymentType = salesRecord.payment.type
        });
    }
