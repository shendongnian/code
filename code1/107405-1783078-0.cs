    foreach(IProduct product in ShoppingCart.Items)
    {
        if (product is Stamp)
        {
            var stamp = product as Stamp;
            Console.WriteLine("Name: {0}, Quantity: {1}, Amount: {2}, UnitPrice: {3}", stamp.Name, stamp.Quantity, stamp.Amount, stamp.UnitPrice);
        }
        else if (product is Letter)
        {
            var letter = product as Letter;
            Console.WriteLine("Name: {0}, Quantity: {1}, Amount: {2}, Weight: {3}, Destination: {4}", letter.Name, letter.Quantity, letter.Amount, letter.Weight, letter.Destination);
        }
        else if (product is Parcel)
        {
            var parcel = product as Parcel;
            Console.WriteLine("Name: {0}, Quantity: {1}, Amount: {2}, Weight: {3}, Destination: {4}, Size: {5}", parcel.Name, parcel.Quantity, parcel.Amount, parcel.Weight, parcel.Destination, parcel.Size);
        }
    }
