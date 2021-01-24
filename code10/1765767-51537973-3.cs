    public async Task<IActionResult> GetMemberList(string BCode)
    {
        Info model = new Info();
        try
        {
            Task<List<B>> getBListTask = Task.Run(() => GetBList());
            Task<List<Member>> memberListTask = Task.FromResult(null);
            if (BCode != null)
            {
                memberListTask = Task.Run(() => GetMemberList(BCode));
            }
            await Task.WhenAll(getBListTask, memberListTask);
            
            model.BList = getBListTask.Result;
            if(BCode != null)
            {
                model.MemberList = memberListTask.Result;
            }
        }
        catch (Exception ex)
        {
            TempData["Msg"] = ex.Message;
        }
        finally
        {
        }
        return View("Index", model);
    }
