    [ResponseType(typeof(void))]    
    public async Task<IHttpActionResult> PutBalanceAsync(GuestAcc guestAcc)
    {
        var guestAccounts = db.GuestAccounts.First(x => x.ReferenceCode == guestAcc.RefCode);
        guestAccounts.Balance = guestAccounts.Balance - guestAcc.Price;
        db.Entry(guestAccounts).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return StatusCode(HttpStatusCode.NoContent);
    }
