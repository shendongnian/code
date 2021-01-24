        double total = 0;
        foreach (var item in quantity_price)
        {
            var quantity = item.Quantity.ToString();
            var double_quantity = Convert.ToDouble(quantity);
            var double_price = Convert.ToDouble(item.Current_price);
            var calc = double_quantity * double_price;
            total += calc;
        }
        ViewBag.Calc = total;
