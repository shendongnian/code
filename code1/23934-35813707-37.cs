	using MyProject.Language;
	namespace MyProject.Core.Models
	{
		public class RegisterViewModel
		{
			[Required(ErrorMessageResourceName = "accountEmailRequired", ErrorMessageResourceType = typeof(Resources))]
			[EmailAddress]
			[Display(Name = "Email")]
			public string Email { get; set; }
		}
	}
