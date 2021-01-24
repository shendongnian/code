    public static void SupprimerEssaieFilament(List<EssaieFilament> essaieFilament_list)
    {
        using (var context = new tp2_1608469Entities1())
        {
            foreach (EssaieFilament essaieFilament in essaieFilament_list)
            {
                if (context.EssaieFilaments.Contains(essaieFilament))
                {
                    context.EssaieFilaments.Remove(essaieFilament);
                    context.SaveChanges();
                }
            }
        }
    }
