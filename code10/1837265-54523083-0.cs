    [HttpGet("commercial")]
    public ActionResult Commercial([FromQuery] OptionsViewModel viewModel)
    {
    ...
    }
    
    public class OptionsViewModel
    {
    	public string FromCcy { get; set; }
    	public string ToCcy { get; set; }
    }
