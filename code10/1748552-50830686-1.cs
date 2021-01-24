    var vh = holder as POSViewHolder;
    vh.MinusClick += MinusClick;
    vh.PlusClick += PlusClick;
    private void MinusClick(object sender, EventArgs e)
    {
        if (sender is RecyclerView.ViewHolder holder)
        {
            var position = holder.AdapterPosition;
            // do other stuff...
        }
    }
