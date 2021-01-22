    private void contextMenuToolStrip_Opening(object sender, CancelEventArgs e)
    {
      var item = propertyGrid.SelectedGridItem;
      resetToolStripMenuItem.Enabled = item != null &&
                                       item.GridItemType == GridItemType.Property &&
                                       item is ITypeDescriptorContext context &&
                                       item.PropertyDescriptor.CanResetValue(context.Instance);
    }
    
    private void resetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      propertyGrid.ResetSelectedProperty();
    }
