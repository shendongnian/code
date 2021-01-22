         HtmlDocument doc = Program.BrowsingSystem.Document;
				HtmlElement ele = doc.GetElementById("button3");
				if (!ConstructionButtonIsAllowedToBePressed(ele))
					return new ActionResponse(false);
				if (ele.GetAttribute("classname").ToLower().Contains("disabled")) //the unit is disabled due to missing resources or other activities running
				{
					return new ActionResponse(false);
				}
				if (ele.GetAttribute("classname").ToLower().Contains("off")) //the unit is unreacheble at this planet level
				{
					return new ActionResponse(false);
				}
				ele = ele.FirstChild.FirstChild.FirstChild.NextSibling;
				object obj = ele.DomElement;
				System.Reflection.MethodInfo mi = obj.GetType().GetMethod("click");
				mi.Invoke(obj, new object[0]);
				
				semaphoreForDocCompletedEvent = WaitForDocumentCompleted(genWaitingTimeForNonEventingActions*2);
			
				ele = doc.GetElementById("planet");
				
				ele = ele.FirstChild.NextSibling.NextSibling;
				obj = ele.DomElement;
				mi = obj.GetType().GetMethod("submit");
				mi.Invoke(obj, new object[0]);
				semaphoreForDocCompletedEvent = WaitForDocumentCompleted(genWaitingTimeForNonEventingActions);
				if (!semaphoreForDocCompletedEvent)
					return new ActionResponse(false);
