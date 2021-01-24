csharp
[HtmlPost]
public ActionResult MyAction(MyModel model)
{
  if (ModelState.IsValid)
  {
    // Do work
  }
  if (ModelState.Keys.Contains("IsRememberMe"))
  {
    ModelState.Remove("IsRememberMe");
  }
  return View(model);
}
