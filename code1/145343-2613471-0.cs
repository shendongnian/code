     var query = orderList.SelectMany( o => o.OrderLineList )
                            // results in IEnumerable<OrderProductVariant>
                          .Select( opv => opv.ProductVariant )
                          .Select( pv => p.Product )
                          .GroupBy( p => p )
                          .Select( g => new {
                                        Product = g.Key,
                                        Count = g.Count()
                           });
