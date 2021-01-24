    Class User : AuthUser {
		[Required]
		public string First Name{get;set;}
		[Required]
		public string Last Name {get;set;}
	}
	Class AuthUser {
		[Required, EmailAddress, MaxLength(256), Display(Name = "Email Address")]
		public string Email {get;set;}
		[Required, MaxLength(20), DataType(DataType.Password), Display(Name ="Password")]
		public string Pasword {get;set;}
	}
