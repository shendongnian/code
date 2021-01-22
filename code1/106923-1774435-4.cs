    public ActionResult Completer(string q)
            {
                if (q != "")
                {
                    NWDataContext db = new NWDataContext();
                    var suggest = from i in db.Customers
                                      .Where(e => e.ContactName.ToLower().StartsWith(q.ToLower()))
                                       select (i.ContactName + "|" + i.CustomerID);
                    return Content(String.Join("\n", suggest.ToArray()));
                }
                return new EmptyResult();
            }
