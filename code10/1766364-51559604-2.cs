    var toDelete = checkboxId.Value
        .Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries)
        .Select( x => {
            int parsedInt= 0;
            var isInt = int.TryParse(x , out parsedInt);
            return new {isInt, parsedInt}
        })
        .Where(x => x.isInt)
        .Select(x=> new {Id= x.parsedInt, Uid=common.GetUserId(x.parsedInt)});
    foreach(var item in toDelete)
    {
        dataContext.MD.DeleteAllOnSubmit(
            dataContext.MD
                .Where(m => m.ID == item.Id && m.UserId == item.Uid)
            )
    }
    dataContext.dc.SubmitChanges();
