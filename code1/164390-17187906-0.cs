    var v = from cs in context.Sal_Customer
             join sag in context.Sal_SalesAgreement
             on cs.CustomerCode equals sag.CustomerCode
             where
              !(
                   from cus in context.Sal_Customer
                   join
                   cfc in context.Sal_CollectionFromCustomers
                   on cus.CustomerCode equals cfc.CustomerCode
                   where cus.UnitCode == locationCode &&
                         cus.Status == Helper.Active &&
                         cfc.CollectionType == Helper.CollectionTypeDRF
                   select cus.CustomerCode
               ).Contains(cs.CustomerCode) &&
               cs.UnitCode == locationCode &&
               cs.Status == customerStatus &&
               SqlFunctions.DateDiff("Month", sag.AgreementDate, drfaDate) < 36
               select new CustomerDisasterRecoveryDetails
               {
                 CustomerCode = cs.CustomerCode,
                 CustomerName = cs.CustomerName,
                 AgreementDate = sag.AgreementDate,
                 AgreementDuration = SqlFunctions.DateDiff("Month", sag.AgreementDate, drfaDate)
       };
