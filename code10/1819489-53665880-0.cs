    @if (ViewBag.UserType == 1)
    {
      Html.RenderPartial("PartialView/_StandardUser");
    }
    else if (ViewBag.UserType == 2)
    {
      Html.RenderPartial("PartialView/_AdminUser");
    }
