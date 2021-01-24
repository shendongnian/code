    protected virtual void PostProcessRows() {
            // If this method is called during a BeginUpdate/EndUpdate pair, changes to the
            // Items collection are cached. Getting the Count flushes that cache.
    #pragma warning disable 168
    // ReSharper disable once UnusedVariable
            int count = this.Items.Count;
    #pragma warning restore 168
            int i = 0;
            if (this.ShowGroups) {
                foreach (ListViewGroup group in this.Groups) {
                    foreach (OLVListItem olvi in group.Items) {
                        this.PostProcessOneRow(olvi.Index, i, olvi);
                        i++;
                    }
                }
            } else {
                foreach (OLVListItem olvi in this.Items) {
                    this.PostProcessOneRow(olvi.Index, i, olvi);
                    i++;
                }
            }
        }
