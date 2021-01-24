    Decimal decVal;
    if (Decimal.TryParse(table[0], decVal))
    {
         model.ErrorList.Add("Medical Total cell must use Number, Currency, or Accounting format.");
    }
    else
    {
         b.MedicalTotal = decVal;
    }
