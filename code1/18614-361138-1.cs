    		protected virtual void RegisterRoutes(IRoutingRuleContainer engine)
		{
			engine.Add
				(
				new PatternRoute(ThorController.CtlrHome, "/[controller]")
					.DefaultForController().Is(ThorController.CtlrHome)
					.DefaultForArea().Is(ThorController.AreaPublic)
					.DefaultForAction().Is(ThorController.ActionIndex)
				);
			engine.Add
				(
				new PatternRoute(ThorController.KeyDefault, "/<area>/<controller>/[action]/[id]")
					.DefaultForArea().Is(ThorController.AreaPublic)
					.DefaultForAction().Is(ThorController.ActionIndex)
					.DefaultFor(ThorController.KeyId).IsEmpty
				);
		}
