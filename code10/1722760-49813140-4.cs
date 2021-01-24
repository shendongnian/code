    public async Task<Brand> Update(Brand brand, IEnumerable<int> SelectedDeliveryDays)
    {
        using (var context = new DbContext([insert connectionString to database here]))
        {
            foreach (int deliveryDayId in SelectedDeliveryDays)
            {
                DeliveryDay deliveryDay = context.DeliveryDays.FirstOrDefault(
                   d => d.DeliveryDayId == deliveryDayId);
                deliveryDay.Brands.Add(brand);
                brand.DeliveryDays.Add(deliveryDay)
                
                // You could also use your custom SetModified method.
                context.Entry(brand).State = EntityState.Modified;
                context.Entry(deliveryDay).State = EntityState.Modified;
            }            
            await context.SaveChangesAsync();
            return brand;
        }
    }
