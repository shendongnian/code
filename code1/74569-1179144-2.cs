          private decimal ProcessNormal(decimal amount) {
               decimal total = 0;
               // continue with your processing:
                if (someCondition)
                    if (someSubCondition)
                        total += amount;
                else if (someOtherCondition)
                    if (someOtherSubCondition)
                        total += amount;
                else if (anotherCondition)
                    total += amount;
              return total;
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
                         amount = fi.ReleasedFederalAmount; 
                         total = ProcessNormal(amount);
                         break;
                    case AmountTypeEnum.ReleasedLocal: 
                         amount = fi.ReleasedLocalAmount; 
                         total = ProcessNormal(amount);
                         break;
                    case AmountTypeEnum.NonReleasedOtherAmount:
                         amount = fi.NonReleasedOtherAmount; 
                         total = ProcessSlightlyDifferently(amount);  // for argument's sake
                         break;
                    default: break;
                }
            }
            return total;
        }
