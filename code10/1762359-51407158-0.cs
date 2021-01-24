                List<Tenants> tenants = new List<Tenants>();
                List<Properties> properties = new List<Properties>();
                List<TenantTransactions> transactions = new List<TenantTransactions>();
                var results = (from t in tenants
                              join p in properties on t.PropertyID equals p.PropertyID
                              join tt in transactions on t.TenantID equals tt.TenantID into ps 
                              from tt in ps.DefaultIfEmpty()
                              select new { t = t, p = p, tt = tt })
                              .Where(x => (x.t.PropertyID == 1) && (x.t.Prospect == 1))
                              .GroupBy(x => x.t.TenantID)
                              .Select(x => new {
                                  tenantID = x.Key,
                                  tenantFirstName = x.FirstOrDefault().t.TenantFName,
                                  tenantLastName = x.FirstOrDefault().t.TenantLName,
                                  rentalAmount = x.FirstOrDefault().t.RentalAmount,
                                  petRent = x.FirstOrDefault().t.PetRent,
                                  houseingAmount = x.FirstOrDefault().t.HousingAmount,
                                  utilityCharge = x.FirstOrDefault().t.UtilityCharge,
                                  tvCharge = x.FirstOrDefault().t.TVCharge,
                                  sercurityDeposit = x.FirstOrDefault().t.SecurityDeposit,
                                  hoaFee = x.FirstOrDefault().t.HousingAmount,
                                  parkingCharge = x.FirstOrDefault().t.ParkingCharge,
                                  storageCharge = x.FirstOrDefault().t.StorageCharge,
                                  concessionAmount = x.FirstOrDefault().t.ConcessionAmount,
                                  concessionReason = x.FirstOrDefault().t.ConcessionReason,
                                  tenantEmail = x.FirstOrDefault().t.TenantEmail,
                                  tenantPhone = x.FirstOrDefault().t.TenantPhone,
                                  tenantCellPhoneProvider = x.FirstOrDefault().t.CellPhoneProviderID,
                                  tenantMoveInDate = x.FirstOrDefault().t.MoveInDate,
                                  propertyID = x.FirstOrDefault().p.PropertyID,
                                  propertyName = x.FirstOrDefault().p.PropertyName,
                                  totalDebit = x.Where(y => (y.tt.TransactionTypeID == 1) && (y.tt.ChargeTypeID != 6) && (y.tt.TenantTransactionDate <= DateTime.Now)).Sum(y => y.tt.TransactionAmount),
                                  housingDebit = x.Where(y => (y.tt.TransactionTypeID == 1) && (y.tt.ChargeTypeID == 6) && (y.tt.TenantTransactionDate <= DateTime.Now)).Sum(y => y.tt.TransactionAmount),
                                  totalCredit = x.Where(y => (y.tt.TransactionTypeID == 2) && (y.tt.ChargeTypeID != 6) && (y.tt.TenantTransactionDate <= DateTime.Now)).Sum(y => y.tt.TransactionAmount),
                                  housingCredit = x.Where(y => (y.tt.TransactionTypeID == 2) && (y.tt.ChargeTypeID == 6) && (y.tt.TenantTransactionDate <= DateTime.Now)).Sum(y => y.tt.TransactionAmount),
                              }).ToList();
            }
        }
        public class TenantTransactions
        {
            public int TenantID { get; set; }
            public int TransactionTypeID{ get;set;}
            public int ChargeTypeID { get;set;}
            public DateTime TenantTransactionDate { get;set;}
            public decimal TransactionAmount { get;set;}
        }
        public class Tenants
        {
            public int PropertyID { get; set; }
            public int Prospect { get; set; }
            public int TenantID { get; set; }
            public string TenantFName { get; set; }
            public string TenantLName { get; set; }
            public decimal RentalAmount { get; set; }
            public decimal PetRent { get; set; }
            public decimal HousingAmount { get; set; }
            public decimal UtilityCharge { get; set; }
            public decimal TVCharge { get; set; }
            public decimal SecurityDeposit { get; set; }
            public decimal HOAFee { get; set; }
            public decimal ParkingCharge { get; set; }
            public decimal StorageCharge { get; set; }
            public decimal ConcessionAmount { get; set; }
            public string ConcessionReason { get; set; }
            public string TenantEmail { get; set; }
            public string TenantPhone { get; set; }
            public string CellPhoneProviderID { get; set; }
            public DateTime MoveInDate { get; set; }
     
        }
        public class Properties
        {
            public int PropertyID { get; set; }
            public string PropertyName { get; set; }
        }
