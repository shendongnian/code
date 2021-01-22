        public ActionResult DoSomething(string param1, string param2)
        {
            if (string.IsNullOrEmpty(param2))
            {
                return DoSomething(ProductName: param1);
            }
            else
            {
                int oldId = int.Parse(param1);
                return DoSomething(OldParam: param1, OldId: oldId);
            }
        }
		
        private ActionResult DoSomething(string OldParam, int OldId)
        {
			// some code here
			return Json(result);
        }
		
		
        private ActionResult DoSomething(string ProductName)
        {
			// some code here
			return Json(result);
        }
		
