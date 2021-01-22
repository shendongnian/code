    var Params = filterContext.RequestContext.HttpContext.Request.Params;
    var dateParts = Params.AllKeys
        .Where(x => x.StartsWith("dateselector-"))
        .Select(x => new {
            Id = x.Substring(x.LastIndexOf('-') + 1),
            Part = x.Remove(x.LastIndexOf('-')).Substring(x.IndexOf('-') + 1),
            Value = Params[x]
        }).GroupBy(x => x.Id)
        .ToDictionary(
            x => x.Key,
            x => x.ToDictionary(y => y.Part, y => y.Value)
        );
    var date = String.Format(
        "{0}-{1}-{2}",
        dateParts["identifier"]["year"],
        dateParts["identifier"]["month"],
        dateParts["identifier"]["day"]
    );
    // UPDATED after comment
    // Params.Add("identifier", date);
    // You can use HttpContext.Items instead:
    filterContext.HttpContext.Items.Add("identifier", date);
