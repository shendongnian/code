    public ActionResult Index(int minSessions = 0)
    {
        var list = from conf in _repository.Query()
                    where conf.SessionCount >= minSessions
                    select conf;
        return AutoMapView<EventListModel[]>(View(list));
    }
