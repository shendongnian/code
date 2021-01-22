    List<Delivery> query2 = (from d in DeliveryList
                             select new Delivery
                             {
                                 DeliveryDate = d.DeliveryDate ?? DateTime.Now,
                                 OrderedDate = d.OrderedDate,
                                 ProductCode = d.ProductCode
                              }).OrderBy(p=>p.DeliveryDate).ToList();
