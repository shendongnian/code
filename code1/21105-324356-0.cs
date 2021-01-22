    public static Instance CreateInstance(int id)
    {
        MyTemplate def = new MyTemplate();
        return def.GetInstance(id);
    }
