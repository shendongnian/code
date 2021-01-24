                strb.Append(" IncPeriodCode as IncetvePeriodCode, PolP.PoliceyPeriodDesc as IncetivePeriodName,");
                strb.Append(" EffectedDate ,EndDate ,pol.SuppCode as SuppCode ,comp.SuppName as SuppName,pol.IsActive from IncentivePolicey pol");
                strb.Append(" LEFT outer join IncentivePoliceyPeriod PolP");
                strb.Append(" ON pol.IncPeriodCode = PolP.PoliceyPeriodCode");
                strb.Append(" LEFT OUTER JOIN Inventory_Suppliers comp ON pol.SuppCode = comp.SuppCode");
