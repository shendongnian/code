    public async Task<Brand> Update(Brand brand, IEnumerable<int> SelectedDeliveryDays)
    {
        using (var context = new DbContext([insert connectionString to database here]))
        {
            foreach (int deliveryDayId in SelectedDeliveryDays)
            {
                DeliveryDay deliveryDay = new DeliveryDay();
                deliveryDay = context.DeliveryDays.FirstOrDefault(
                   d => d.DeliveryDayId == deliveryDayId);
                   //when adding following line it works but also insert duplicate values in DeliveryDays table
                   dc.DeliveryDays.Add(deliveryDay);
                brand.DeliveryDays.Add(deliveryDay);
            }
            context.Entry(brand).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return brand;
        }
    }
