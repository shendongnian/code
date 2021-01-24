    Decimal decVal;
    if (Decimal.TryParse(table[0], out decVal))
    {
         b.MedicalTotal = decVal;
    }
    else
    {
         model.ErrorList.Add("Medical Total cell must use Number, Currency, or Accounting format.");
    }
