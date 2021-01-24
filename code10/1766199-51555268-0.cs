            OleDbCommand commandBlouseName = new OleDbCommand();
            commandBlouseName.Connection = connection;
            commandBlouseName.CommandText = "SELECT * FROM BlouseTable WHERE blouseName='" + blouse.BlouseName + "'";
            OleDbDataReader readerBlouseName = commandBlouseName.ExecuteReader();
            int count = 0;
            while (readerBlouseName.Read())
            {
                count++;
            }
            if (count == 1)
            {
                //Has 1 same name registered
            }
            if (count < 1)
            {
                //Create new one
                //There is no Blouse Name registered with same name
            }
            if (count > 1)
            {
                //More than 1 that Blouse Name registered
            }
