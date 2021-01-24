     public async Task<List<GetAllOrdersResult>> AdminGetOrderList()
                {
                    using (var db = new SoulDrawContext())
                    {
                                      var query = from A in db.Orders group A by A.OrderId into g 
                                        join B in db.OrderMeta
                                        on g.FirstOrDefault().OrderId equals B.OrderId
                                        select new GetAllOrdersResult
                                        {
                                            OrderId = g.FirstOrDefault().OrderId,
                                            UserId = g.FirstOrDefault().UserId,
                                            OrderDate = g.FirstOrDefault().OrderDate.ToLocalTime().ToString("yyyy-MM-dd"),
                                            Currency = g.FirstOrDefault().Currency,
                                            Amount = g.FirstOrDefault().Amount,
                                            PaymentMethod = g.FirstOrDefault().PaymentMethod,
                                            ShipTo = g.FirstOrDefault().ShipTo,
                                            Status = B.Status,//now your B in scope so you can use Directly
                                            PostDate = B.PostDate.ToLocalTime().ToString("yyyy-MM-dd hh:mm"),
                                            RefOrderId = g.FirstOrDefault().RefOrderId
                                        };
                             query.OrderBy(B.PostDate);
                            return await query.ToListAsync();
                        }
               }
