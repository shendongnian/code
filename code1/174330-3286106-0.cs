    public Coinage AddCopper(int amount)
    {
        return new Coinage(_value + amount);
    }
    
    public Coinage AddSilver(int amount)
    {
        return new Coinage(_value + (amount * 100));
    }
