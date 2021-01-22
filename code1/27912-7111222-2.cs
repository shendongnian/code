		[HttpPost]
		[MultipleButton(Name = "action", Argument = "Send")]
		public ActionResult Send(MessageModel mm) { ... }
		[HttpPost]
		[MultipleButton(Name = "action", Argument = "Save")]
		public ActionResult Save(MessageModel mm) { ... }
