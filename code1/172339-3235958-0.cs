    public sealed class WorkSheet : ItemsControl
    {
        /// <inheritdoc />
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return (item is WorkTile);
        }
    }
