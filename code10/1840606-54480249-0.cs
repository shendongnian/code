    var query = (from partners in session.Query<Partners>()
                         where partners.PartnerId == partnerId
                         let partnerUsers = (from pu in session.Query<PartnerUsers>()
                                             where pu.PartnerId == partners.PartnerId
                                             select pu).ToList()
                         select new Partnersss
                         {
                             PartnerId = partners.PartnerId,
                             PartnerName = partners.Name,
                             PartnerUsers = partnerUsers
                         }).ToList();
