	var actionResult = controller.Index();
	actionResult.ShouldBeInstanceOf<AutoMapViewResult>();
	var autoMapViewResult = (AutoMapViewResult) actionResult;
	autoMapViewResult.DestinationType.ShouldEqual(typeof(EventListModel[]));
	autoMapViewResult.View.ViewData.Model.ShouldEqual(queryResult);
	autoMapViewResult.View.ViewName.ShouldEqual(string.Empty);
