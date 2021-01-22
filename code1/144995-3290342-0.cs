    public class Financial
    {
        #region Methods
        public static decimal IPmt(decimal Rate, decimal Per, decimal NPer, decimal PV, decimal FV, FinancialEnumDueDate Due)
        {
            decimal num;
            if (Due != FinancialEnumDueDate.EndOfPeriod)
            {
                num = 2;
            }
            else
            {
                num = 1;
            }
            if ((Per <= 0) || (Per >= (NPer + 1)))
            {
                //Argument_InvalidValue1=
                throw new ArgumentException("Argument 'Per' is not a valid value.");
            }
            if ((Due != FinancialEnumDueDate.EndOfPeriod) && (Per == 1))
            {
                return 0;
            }
            decimal pmt = Pmt(Rate, NPer, PV, FV, Due);
            if (Due != FinancialEnumDueDate.EndOfPeriod)
            {
                PV += pmt;
            }
            return (FV_Internal(Rate, Per - num, pmt, PV, FinancialEnumDueDate.EndOfPeriod) * Rate);
        }
        public static decimal PPmt(decimal Rate, decimal Per, decimal NPer, decimal PV, decimal FV, FinancialEnumDueDate Due)
        {
            if ((Per <= 0) || (Per >= (NPer + 1)))
            {
                throw new ArgumentException("Argument 'Per' is not valid.");
            }
            decimal num2 = Pmt(Rate, NPer, PV, FV, Due);
            decimal num = IPmt(Rate, Per, NPer, PV, FV, Due);
            return (num2 - num);
        }
        static decimal FV_Internal(decimal Rate, decimal NPer, decimal Pmt, decimal PV, FinancialEnumDueDate Due)
        {
            decimal num;
            if (Rate == 0)
            {
                return (-PV - (Pmt * NPer));
            }
            if (Due != FinancialEnumDueDate.EndOfPeriod)
            {
                num = 1 + Rate;
            }
            else
            {
                num = 1;
            }
            decimal x = 1 + Rate;
            decimal num2 = (decimal)Math.Pow((double)x, (double)NPer);
            return ((-PV * num2) - (((Pmt / Rate) * num) * (num2 - 1)));
        }
        static decimal Pmt(decimal Rate, decimal NPer, decimal PV, decimal FV, FinancialEnumDueDate Due)
        {
            decimal num;
            if (NPer == 0)
            {
                throw new ArgumentException("Argument NPer is not a valid value.");
            }
            if (Rate == 0)
            {
                return ((-FV - PV) / NPer);
            }
            if (Due != FinancialEnumDueDate.EndOfPeriod)
            {
                num = 1 + Rate;
            }
            else
            {
                num = 1;
            }
            decimal x = Rate + 1;
            decimal num2 = (decimal)Math.Pow((double)x, (double)NPer);
            return (((-FV - (PV * num2)) / (num * (num2 - 1))) * Rate);
        }
        #endregion Methods
    }
