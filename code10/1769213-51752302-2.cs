     using (var _dc = new BulkTestEntities())
                    {
                        var _custs = _dc.Customers.Include("Products").Include("CustomerType").ToList();
    
    
                       // CopyPropertyData.CopyObjectPropertyData(_custs, _resp);
                        //foreach(var cust in _custs)
                        //{
                        //    _resp.Add(cust.CopyToModelProperties<CustomerModel>());
                        //}
    
                        foreach (var cust in _custs)
                        {
                            CustomerModel _newCust = new CustomerModel();
    
                            SQLExtensions.CopyToModelProperties(cust, _newCust);
                          //  CopyData.CopyObjectData(cust, _newCust);
    
                            _resp.Add(_newCust);
                        }
                    }
