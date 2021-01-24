    @using (Html.BeginForm())
    {
      @Html.AntiForgeryToken();
      @Html.EditorForModel();
      <input type="submit" value="Submit" />
    }
     
    [HttpPost]
    [ValidateAntiForgeryToken()]
    public ActionResult Index(User user)
    {
      ...
    }
