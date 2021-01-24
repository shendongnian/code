    public JsonResult SpinText([FromBody]SpinningInput spinningInput)
    {
    	SpinningResult spinningResult = new SpinningResult();
    	spinningResult = Utility.Spinning.SpinText(spinningInput);
    
    	return Json(spinningResult);
    }
