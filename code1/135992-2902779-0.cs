    public class UpdateSomethingViewModel {
    	[DisplayName("evidence")]
    	[Required(ErrorMessage="You must provide evidence")]
    	[RegularExpression(@"^abc123.jpg$", ErrorMessage="Stuff and nonsense")]
    	public HttpPostedFileWrapper Evidence { get; set; }
    }
