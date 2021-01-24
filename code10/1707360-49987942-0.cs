        public string ConvertValue(Int64 Value)
        {
            string[] ValueNames = { "Billion", "Trillion" ... };
            int index;
            for (index = 0; index < ValueNames.GetLength(0); index++)
            {
                Int64 NewValue = Value / 1000;
                if (NewValue == 0)
                {
                    break;
                }
                else
                {
                    Value = NewValue;
                }
            }
            return Value.ToString() + ValueNames[index];
        }
