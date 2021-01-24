    [HttpPost]
    public IHttpActionResult PostCombinedPOResponse([FromBody] string inputXml)
    {
        AddPurchaseOrderResponse response = new AddPurchaseOrderResponse();
        //...
        return Ok(response);
    }
