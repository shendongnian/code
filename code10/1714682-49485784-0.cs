    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    {
        ...
        FillEventsUnderDate(viewGroupHelper, position, eventsUnderDate);
    }
    private void FillEventsUnderDate(ViewGroup parent, int position, List<Event> events)
    {   
        foreach (Event @event in events)
        {
            //this holder is never used by RecyclerView
            EventViewHolder holder = CreateViewHolder(parent, TYPE_EVENT) as EventViewHolder;
            BindViewHolder(holder, position++);
        }
    }
