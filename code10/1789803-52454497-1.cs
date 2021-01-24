    while ((line = r.ReadLine()) != null)
    {
        try
        {
            string[] parts = line.Split(',');
            // Skip the column names row
            if (parts[0] == "id") continue;
            CustomerModel dbp = new CustomerModel
            {
                CustomerId = Convert.ToInt32(parts[0]),
                CustomerName = parts[1],
                CustomerState = parts[2],
                ProductId = Convert.ToInt32(parts[3]),
                QuantityBought = Convert.ToInt32(parts[4])
            };
            allFileCustomerData.Add(dbp);
        }
        catch (FormatException ex)
        {
        }
        catch (Exception ex)
        {
            throw;
        }
    }
