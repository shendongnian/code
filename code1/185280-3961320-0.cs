    public void UpdatePai(int id, string field1, string field2, int field3)
    {
        PaisRepository repository = new PaisRepository();
        Pai pai = repository.Get(id);
        pai.Field1 = field1;
        pai.Field2 = field2;
        pai.Field3 = field3;
        pai.Save();        
    }
