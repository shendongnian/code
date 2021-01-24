    public class PrestationResultNormal
    {
        public List<ItemPrestation> prestations;
        
        public PrestationResultNormal(List<Prestation> prestations)
        {
            this.prestations = prestations.Select(x => new ItemPrestation()
            {
                IdPrestation = x.IdPrestation,
                NomPrestation = x.NomPrestation
            }).ToList();
        }
    }
