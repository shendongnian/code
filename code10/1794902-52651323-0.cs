      public static Role {
		public static string Admin ="Admin";
		public static string IT ="IT";
	  }
     [Authorize(Roles = Role.Admin,Role.IT)]
     public ActionResult Index()
     {
     }
