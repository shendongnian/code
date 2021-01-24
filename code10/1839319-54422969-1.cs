        public class ModuleViewHolder : RecyclerView.ViewHolder
        {
            // Get references to the views defined in the CardView layout.
            public ModuleViewHolder (View itemView, Action<int> listener) 
                : base (itemView)
            {
     on the item view and report which item
                // was clicked (by layout position) to the listener:
                itemView.Click += (sender, e) => listener (base.LayoutPosition);
            }
        }
