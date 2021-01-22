        public Item Parent
        {
            get { return this.parent; }
            set
            {
                if (this.parent != value)
                {
                    // Update the parent field before modifing the child
                    // collections to fail the test this.parent != value
                    // when the child collection accesses this property.
                    // Keep a copy of the  old parent  for removing this
                    // item from its child collection.
                    Item oldParent = this.parent;
                    this.parent = value;
                    if (oldParent != null)
                    {
                        oldParent.Children.Remove(this);
                    }
                    if (value != null)
                    {
                        value.Children.Add(this);
                    }
                }
            }
        }
        private Item parent = null;
    }
