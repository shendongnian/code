    void TrackChange(Sample other, List<Change> changes)
    {
        if (this.Id != other.Id) changes.add(new Change(...));
        if (this.Date != other.Date) changes.add(new Change(...));
        if (this.Grocers.count != other.Grocers.count) changes.add(new Change(...)); // number of items has changed
        for (int i = 0; i < math.min(this.grocers.count, other.grocers.count); i++)
            this.grocers[i].TrackChange(other.grocers[i], changes);
        ....
    }
