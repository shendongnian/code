    public IQueryable<Pet> FindPetsNotOnVisit(int id)
    {
        Visit visit = GetVisit(id);
        var pets = FindCustomerPets(visit.CustomerId);
    
        var petIds = from visitDetail in db.VisitDetails
                     where visitDetail.VisitID == id
                     select visitDetail.PetID;
    
        return pets.Where(p => !petIds.Contains(p.PetID));
    }
