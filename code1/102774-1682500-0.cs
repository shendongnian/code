    IEnumerator<IThing> IEnumerable<IThing>.GetEnumerator()
    {
        // This calls itself over and over
        return this.Cast<IThing>().GetEnumerator();
    }
