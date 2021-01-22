    public IEnumerable<Canine> LetTheDogsOut(int personID) {
      return nhSession.GetNamedQuery("spGoGetMyDogs")
        .SetInt32("personID", personID)
        .SetResultTransformer(Transformers.AliasToBean(typeof(Canine)))
        .List<Canine>();
    }
