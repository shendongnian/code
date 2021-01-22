            string result = string.Empty;
            int rem = 0;
            try
            {
                if (!IsNumeric(data))
                    error = "Invalid Value - This is not a numeric value";
                else
                {
                    int num = int.Parse(data);
                    while (num > 0)
                    {
                        rem = num % 2;
                        num = num / 2;
                        result = rem.ToString() + result;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return result;
        }
