    public static void SupprimerEssaieFilament(List<EssaieFilament> essaieFilament_list)
    {
        using (var context = new tp2_1608469Entities1())
        {
           context.EssaieFilaments.RemoveRange(
              essaieFilament_list.Select(x=> new EssaieFilament(){Id = x.Id}));
            
           context.SaveChanges();
        }
    }
