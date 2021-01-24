    using System;
    using System.ComponentModel.DataAnnotations;
    namespace MvcRequiredCheckbox
    {
	    public class SampleViewModel
	    {
		    [Display(Name = "Terms and Conditions")]
		    [Range(typeof(bool), "true", "true", ErrorMessage = "You gotta tick the box!")]
		    public bool TermsAndConditions { get; set; }	
	    }
    }
