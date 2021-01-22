    private List<EventHandler> handlers = new List<EventHandler>();
    public event EventHandler MealRequired
    {
        add { handlers.Add(value); }
        remove
        {
            int index = handlers.LastIndexOf(value);
            if (index != -1)
            {
                handlers.RemoveAt(index);
            }
        }
    }
