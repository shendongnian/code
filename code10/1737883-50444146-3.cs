    internal void changeState(int position)
    {
        if (mList[position] == 1)
        {
            mList[position] = 0;
        }
        else {
            mList[position] = 1;
        }
        this.NotifyDataSetChanged();
    }
