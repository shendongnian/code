    private ArrayList modulos;
    
    public void AddModulo(Modulo m)
    {
        modulos.Add(m);
    }
    
    public bool RemoveModulo(Modulo m)
    {
        return modulos.Remove(m);
    }
