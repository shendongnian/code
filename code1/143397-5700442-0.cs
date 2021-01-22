            string ReceivedId = string.Empty;
            string displayString = string.Empty;
            String query = "SELECT MAX(OrderReceivedNo) FROM [Order_Received]";
            String data = DataManager.RunExecuteScalar(ConnectionString.Constr, query);
            ReceivedId = data;
            if (string.IsNullOrEmpty(ReceivedId))
            {
                ReceivedId = "OR0000";//It is the start index of alpha numeric value
            }
            int len = ReceivedId.Length;
            string splitNo = ReceivedId.Substring(2, len - 2);//This line will ignore the string values and read only the numeric values
            int num = Convert.ToInt32(splitNo);
            num++;// Increment the numeric value
            displayString = ReceivedId.Substring(0, 2) + num.ToString("0000");//Concatenate the string value and the numeric value after the increment
            return displayString;
        }
