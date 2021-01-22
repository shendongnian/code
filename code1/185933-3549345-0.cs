            string s1 = "1234";
            string s2 = "1234.65";
            string s3 = null;
            string s4 = "12345678901234567890123456789012345678901234567890";
            int result;
            bool success;
            result = Int32.Parse(s1);      // 1234
            result = Int32.Parse(s2);      // FormatException
            result = Int32.Parse(s3);      // ArgumentNullException
            result = Int32.Parse(s4);      // OverflowException
            result = Convert.ToInt32(s1);      // 1234
            result = Convert.ToInt32(s2);      // FormatException
            result = Convert.ToInt32(s3);      // 0
            result = Convert.ToInt32(s4);      // OverflowException
            success = Int32.TryParse(s1, out result);      // 1234
            success = Int32.TryParse(s2, out result);      // 0
            success = Int32.TryParse(s3, out result);      // 0
            success = Int32.TryParse(s4, out result);      // 0
