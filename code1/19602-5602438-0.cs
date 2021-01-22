    var model = new SubjectViewModel()
    {
       Subject = new Subject(),
       Types = data.SubjectTypes.ToList()
    }
    model.Subject.SubjectType = model.Types.FirstOrDefault(t => t.Id == typeId);
    ViewData.Model = model;
    return View();
