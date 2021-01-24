     private void setSelectedPosition(int position)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                list[i].setSelected(i == position);
            }
            NotifyDataSetChanged();
        }
