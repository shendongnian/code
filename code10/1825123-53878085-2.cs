	public virtual void Drop(IDropInfo dropInfo)
	{
		if (dropInfo != null && dropInfo.DragInfo != null)
		{
			int insertIndex = (dropInfo.InsertIndex != dropInfo.UnfilteredInsertIndex) ? dropInfo.UnfilteredInsertIndex : dropInfo.InsertIndex;
			ItemsControl itemsControl = dropInfo.VisualTarget as ItemsControl;
			if (itemsControl != null)
			{
				IEditableCollectionView editableItems = itemsControl.Items;
				if (editableItems != null)
				{
					NewItemPlaceholderPosition newItemPlaceholderPosition = editableItems.NewItemPlaceholderPosition;
					if (newItemPlaceholderPosition == NewItemPlaceholderPosition.AtBeginning && insertIndex == 0)
					{
						insertIndex++;
					}
					else if (newItemPlaceholderPosition == NewItemPlaceholderPosition.AtEnd && insertIndex == itemsControl.Items.Count)
					{
						insertIndex--;
					}
				}
			}
			IList destinationList = dropInfo.TargetCollection.TryGetList();
			List<object> data = ExtractData(dropInfo.Data).OfType<object>().ToList();
			List<object>.Enumerator enumerator;
			if (!ShouldCopyData(dropInfo))
			{
				IList sourceList = dropInfo.DragInfo.SourceCollection.TryGetList();
				if (sourceList != null)
				{
					enumerator = data.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							object o2 = enumerator.Current;
							int index = sourceList.IndexOf(o2);
							if (index != -1)
							{
								sourceList.RemoveAt(index);
								if (destinationList != null && object.Equals(sourceList, destinationList) && index < insertIndex)
								{
									insertIndex--;
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
				}
			}
			if (destinationList != null)
			{
				TabControl tabControl = dropInfo.VisualTarget as TabControl;
				bool cloneData = dropInfo.Effects.HasFlag(DragDropEffects.Copy) || dropInfo.Effects.HasFlag(DragDropEffects.Link);
				enumerator = data.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object o = enumerator.Current;
						object obj2Insert = o;
						if (cloneData)
						{
							ICloneable cloneable = o as ICloneable;
							if (cloneable != null)
							{
								obj2Insert = cloneable.Clone();
							}
						}
						destinationList.Insert(insertIndex++, obj2Insert);
						if (tabControl != null)
						{
							TabItem obj = tabControl.ItemContainerGenerator.ContainerFromItem(obj2Insert) as TabItem;
							if (obj != null)
							{
								obj.ApplyTemplate();
							}
							tabControl.SetSelectedItem(obj2Insert);
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
		}
	}
