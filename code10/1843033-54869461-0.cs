                if (_userService.GetDBName() == "ALL")
            {
                // If Factory selected is ALL, grab all user factories DBName in a list
                var factories = _adm.GetUserFactoriesForCombo(_userService.GetUserId()).Where(f => f.FactoryId > 0);
                // Get all PruchaseOrders from all factories
                List<PurchaseOrders> pos = new List<PurchaseOrders>();
                foreach (var f in factories)
                {
                    using (var uow = new OperationsUOW(new OperationsContext(_userService.GetDBContext(f.FactoryDB)), _userService))
                    {
                        var npos = uow.PurchaseOrders.GetAll();
                        pos.AddRange(npos);
                    }
                }
                return pos;
            }
