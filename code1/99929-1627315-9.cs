    public ActionResult Action()
    {
      // now you can Html.EditorFor(x => x.StringValue) and it will pick attributes
      return View(new { StringValue = new TextBoxViewModel(x.StringValue).Attr("class", "myclass").Attr("size", 15) });
    }
