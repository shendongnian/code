    foreach (SalesOrders item in purchaseOrder)
                {
                    using (StreamWriter sw = new StreamWriter($"SalesOrder_{item.OrderNumber.ToString()}.csv"))
                    {
                        var lines = TakeAllStuffFrom(item); // like a collection of $"{SalesOrder.FirstField.Trim()};{SalesOrder.SecondField.Trim()}";
                        foreach (var line in lines)
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
