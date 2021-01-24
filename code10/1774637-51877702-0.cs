    public float ObtenirCoeficient(int id)
    {
        using (var context = new BddContext1())
        {
            var fonctionName = context.Inputs.FirstOrDefault(input => input.Id == id)?.Fonction;
            return context.FonctionsPersonnels.FirstOrDefault(p => p.Nom == fonctionName).Cote;
        }
    }
