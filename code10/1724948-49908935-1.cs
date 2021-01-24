    var MaxPriceInPLN = db.Bids.Max(b => b.PriceInPLN);
    var ans = from U in db.Users
              where !U.Roles.Any(r => r.RoleId == adminRoleId)
              join b in db.Bids on U.Id equals b.ApplicationUserId into bj
              from b in bj.DefaultIfEmpty()
              group new { U, b } by new { U.Id, U.UserName, U.Email } into Ubg
              let maxBidPriceInPLN = Ubg.Max(Ub => Ub.b.PriceInPLN)
              select new {
                  Ubg.Key.Id,
                  Ubg.Key.UserName,
                  Ubg.Key.Email,
                  PriceInPLN = maxBidPriceInPLN ?? 0,
                  BidsCount = Ubg.Count(Ub => Ub.b != null),
                  IsMax = maxBidPriceInPLN == MaxPriceInPLN
              };
