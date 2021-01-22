    public Post Post 
    {
        set
        {
            if (value is Question)
            {
                question = (Question)value;
            }
        }
    }
