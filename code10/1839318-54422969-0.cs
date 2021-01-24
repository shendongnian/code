    public class ModuleClassContainerAdapter  : RecyclerView.Adapter
        {
            // Event handler for item clicks:
            public event EventHandler<int> ItemClick;
    
    // Create a new photo CardView (invoked by the layout manager): 
            public override RecyclerView.ViewHolder 
                OnCreateViewHolder (ViewGroup parent, int viewType)
            {
                // You need to pass the event 
                ModuleViewHolder vh = new ModuleViewHolder (itemView, OnClick); 
                return vh;
            }
    
            // Raise an event when the item-click takes place:
            void OnClick (int position)
            {
                if (ItemClick != null)
                    ItemClick (this, position);
            }
