            string x = "123456";
            StringBuilder y = new StringBuilder(x.Length * 2);
    
            for (int i = x.Length - 1; i >= 0; i--)
            {
                y.Append(x[i]);
                y.Append(".");
            }
