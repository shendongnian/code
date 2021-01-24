    @Html.ActionLink("Details", "Details", new {id= @item.TRACK_NMBR, id2 =@item.TRANS_DT});
    
    public async Task<ActionResult> Details(int? id, DateTime id2)
    {
    FILE_RCPTS_LOG obj = db.FILE_RCPTS_LOG.Find(id, id2);
    }
