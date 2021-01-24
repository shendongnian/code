    public static void SupprimerEssaieFilament(List<EssaieFilament> essaieFilament_list)
    {
        using (var context = new tp2_1608469Entities1())
        {
            var itemIds = essaieFilament_list.Select(x=>x.Id);
            var itemsToDelete = context.EssaieFilaments.Where(x=>itemsIds.Contains(x.Id));
            
            context.EssaieFilaments.RemoveRange(itemsToDelete);
            context.SaveChanges();
        }
    }
    
