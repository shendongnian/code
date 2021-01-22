     // define some enum for your callers to use
     public enum AmountTypeEnum {
         ReleasedFederal = 1
     ,   ReleasedLocal = 2
     }
     public decimal GetTotalAmountByDate(AmountTypeEnum type)
        {
            if (BeginDate == null && EndDate == null)
                return 0;
            decimal total = 0;
            foreach (var fi in Financials)
            {
                // declare a variable that will hold the amount:
                decimal amount = 0;
                // here's the switch:
                switch(type) {
                    case AmountTypeEnum.ReleasedFederal: 
                         amount = fi.ReleasedFederalAmount; break;
                    case AmountTypeEnum.ReleasedLocal:
                         amount = fi.ReleasedLocalAmount; break;
                    default: break;
                }
                // continue with your processing:
                if (someCondition)
                    if (someSubCondition)
                        total += amount;
                else if (someOtherCondition)
                    if (someOtherSubCondition)
                        total += amount;
                else if (anotherCondigion)
                    total += amount;
            }
            return total;
        }
