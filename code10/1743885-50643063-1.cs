    List<decimal> Calc = new List<decimal>();
            foreach (var item in quantity_price)
            {
                var quantity = item.Quantity.ToString();
                var double_price = Convert.ToDecimal(item.Current_price);
                var calc = item.Quantity * double_price;
                Calc.Add(calc);               
            }
            ViewBag.Calc = Calc;
