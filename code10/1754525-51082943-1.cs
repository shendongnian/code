      public async Task UpdateAuctionStatus(AuctionReturnModel model)
        {
            try
            {
                var _auction = await (from d in _db.Auction_Detail where d.Id == model.AuctionDetailId select d).FirstOrDefaultAsync();
                _auction.isEnded = true;
                _db.Auction_Detail.Add(_auction);
                _db.SaveChanges();
                var _auctionHistory = new AuctionHistory { AuctionDetail_Id = model.AuctionDetailId, EndedDate = DateTime.Now, EndedMethod = "Automatic" };
                _db.AuctionHistory.Add(_auctionHistory);
                _db.SaveChanges();
                Task.WaitAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
