        public void QuickTest()
        {
            object stringObj = "string";
            object nullableInt1 = (int?)null;
            object nullableInt2 = (int?)1;
            object decimalObj = 1.5m;
            ProcessObject(stringObj);
            ProcessObject(nullableInt1);
            ProcessObject(nullableInt2);
            ProcessObject(decimalObj);
        }
        public void ProcessObject(object value)
        {
            if (value == null)
            {
                Debug.WriteLine("null");
                return;
            }
            
            if (value is string)
            {
                Debug.WriteLine((string)value);
                return;
            }
            string stringValue = value.ToString();
            int intTemp;
            if (int.TryParse(stringValue, out intTemp))
            {
                Debug.WriteLine(intTemp);
                return;
            }
            decimal decimalTemp;
            if (decimal.TryParse(stringValue, out decimalTemp))
            {
                Debug.WriteLine(decimalTemp);
                return;
            }
            // etc...
        }
