    if (device.Quantity <= 0)
                {
                    foreach (var outOfStockItem in cart)
                    {
                        string messages = string.Format("Out of stock for {0}. In stock: {1}. | ", outOfStockItem.Device.DeviceName, outOfStockItem.Device.Quantity);
                        TempData["Messages"] += messages;
                    }
                    return View("Cart");
                }
