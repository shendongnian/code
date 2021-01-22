    public ActionResult GetMostRecentTransaction(int singleId)
    {
    using (var db = new DataClasses1DataContext())
    {
        var transaction = (from t in db.Transactions
                              orderby t.WhenCreated descending
                              where t.Id == singleId
                              select t).SingleOrDefault();
        return PartialView("_transactionPartial", transaction);
    }
}
