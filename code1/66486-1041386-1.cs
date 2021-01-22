    public sealed override bool IsValidForRequest
        (ControllerContext cc, MethodInfo mi)
    {
        _ControllerContext = cc;
        var map = new Dictionary<CheckType, Func<bool>>
            {
                { CheckType.Form, () => CheckForm(cc.HttpContext.Request.Form) },
                { CheckType.Parameter,
                    () => CheckParameter(cc.HttpContext.Request.Params) },
                { CheckType.TempData, () => CheckTempData(cc.Controller.TempData) },
                { CheckType.RouteData, () => CheckRouteData(cc.RouteData.Values) }
            };
        foreach (var item in map)
        {
            if ((item.Key & _CheckType) == item.Key)
            {
                if (item.Value())
                {
                    return true;
                }
            }
        }
        return false;
    }
