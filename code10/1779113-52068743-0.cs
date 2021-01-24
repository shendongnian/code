    public async Task<object> getCredits(int id){
        dynamic response = new JObject();
        try {
              decimal credit = await _context.walletTrans.ToAsyncEnumerable().Where(r => r.Id == id).Sum(s => s.quantity);
              response.Credit = credit;
              return response;
            } catch (Exception e) {
                response.Error = e;
                return response;
            }
    }
