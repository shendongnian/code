    using System;
    using System.Collections.Generic;
    using Infragistics.Windows.DataPresenter;
    using System.Windows.Interactivity;
    using System.Windows;
    using Infragistics.DragDrop;
    using System.Windows.Input;
    using Infragistics.Windows;
    using System.Collections;
    using System.Windows.Media;
    using System.Reflection;
    
    namespace DragGrid
    {
        public class XamDataGridDragDropBehavior : Behavior<DataPresenterBase>
        {
            private DataPresenterBase dataPresenter;
    
            protected override void OnAttached()
            {
                base.OnAttached();
                dataPresenter = this.AssociatedObject;
                EventManager.RegisterClassHandler(typeof(XamDataGrid), UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(XamDataGrid_MouseLeftButtonDown));
                var dataPresenterStyle = new Style(typeof(DataRecordPresenter));
                dataPresenterStyle.Setters.Add(new EventSetter(FrameworkElement.LoadedEvent, new RoutedEventHandler(OnRecordPresenterLoaded)));
                dataPresenter.Resources.Add(typeof(DataRecordPresenter), dataPresenterStyle);
                DropTarget dropTarget = new DropTarget() { IsDropTarget = true };
                DragDropManager.SetDropTarget(dataPresenter, dropTarget);
            }
    
            private void OnRecordPresenterLoaded(object sender, RoutedEventArgs e)
            {
    
                var recordPresenter = sender as DataRecordPresenter;
    
                if (DragDropManager.GetDragSource(recordPresenter) != null)
                {
                    return;
                }
    
                var dragSource = new DragSource
                {
                    IsDraggable = true
                };
    
                dragSource.DragStart += new System.EventHandler<DragDropStartEventArgs>(dragSource_DragStart);
                dragSource.Drop += OnRecordDragDrop;
                dragSource.DragTemplate = ((Window)Utilities.GetAncestorFromType(this.dataPresenter, typeof(Window), true)).Resources["dragTemplate"] as DataTemplate;
    
                DragDropManager.SetDragSource(recordPresenter, dragSource);
            }
    
            void dragSource_DragStart(object sender, DragDropStartEventArgs e)
            {
                ArrayList draggedItems = new ArrayList();
                List<IList> sourceList = new List<IList>();
                SelectedRecordCollection selectedRecords = this.dataPresenter.SelectedItems.Records;
                DataRecord lastSelectedDataRecord = null;
                foreach (Record r in selectedRecords)
                {
                    DataRecord dr = r as DataRecord;
                    if (dr != null)
                    {
                        lastSelectedDataRecord = dr;
                        draggedItems.Add(dr.DataItem);
                        sourceList.Add(GetSourceList(dr));
                    }
                }
                DraggingData data = new DraggingData();
                data.Items = draggedItems;
                data.Lists = sourceList;
                if (lastSelectedDataRecord != null && lastSelectedDataRecord.ParentRecord != null)
                {
                    data.SourceProperty = lastSelectedDataRecord.RecordManager.Field.Name;
                }
                e.Data = data;
            }
    
            private IList GetSourceList(DataRecord record)
            {
                IList retVal = null;
                DataRecord parent = record.ParentDataRecord;
                if (parent == null)
                {
                    // There is no parent, use the grids list
                    retVal = this.dataPresenter.DataSource as IList;
                }
                else
                {
                    object parentDataItem = parent.DataItem;
                    Type dataItemType = parentDataItem.GetType();
                    PropertyInfo listProperty = dataItemType.GetProperty(record.RecordManager.Field.Name);
                    retVal = listProperty.GetValue(parentDataItem, null) as IList;
                }
                return retVal;
            }
    
            private void OnRecordDragDrop(object sender, DropEventArgs dragInfo)
            {
                var result = VisualTreeHelper.HitTest(dragInfo.DropTarget, dragInfo.GetPosition(dragInfo.DropTarget));
                var targetElement = Utilities.GetAncestorFromType(result.VisualHit, typeof(DataRecordPresenter), true) as DataRecordPresenter;
                if (targetElement != null)
                {
                    DataRecord targetRecord = targetElement.DataRecord;
                    IList targetList = GetSourceList(targetRecord);
                    object targetItem = targetRecord.DataItem;
                    Type targetType = targetItem.GetType();
                    DraggingData draggedData = dragInfo.Data as DraggingData;
                    if (draggedData != null)
                    {
                        IList itemsList = draggedData.Items;
                        object firstItem = itemsList[0];
                        IList<IList> listsList = draggedData.Lists;
                        if (!targetType.IsInstanceOfType(firstItem))
                        {
                            // the target type doesn't match the items we are dropping, get the child list from the parent if we have a property.
                            if (draggedData.SourceProperty != null)
                            {
                                PropertyInfo listProperty = targetType.GetProperty(draggedData.SourceProperty);
                                targetList = listProperty.GetValue(targetItem, null) as IList;
                                if (targetList != null)
                                {
                                    for (int i = itemsList.Count - 1; i >= 0; i--)
                                    {
                                        object currentItem = itemsList[i];
                                        int targetIndex = targetList.IndexOf(targetItem);
                                        listsList[i].Remove(currentItem);
                                        targetList.Add(currentItem);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Can't drop here");
                            }
                        }
                        else
                        {
                            for (int i = itemsList.Count - 1; i >= 0; i--)
                            {
                                object currentItem = itemsList[i];
                                int targetIndex = targetList.IndexOf(targetItem);
                                listsList[i].Remove(currentItem);
                                targetList.Insert(targetIndex, currentItem);
                            }
                        }
                    }
    
                }
            }
    
            void XamDataGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                if (this.dataPresenter.Equals(sender))
                {
                    DataRecordPresenter drp = Utilities.GetAncestorFromType(e.OriginalSource as DependencyObject, typeof(DataRecordPresenter), true) as DataRecordPresenter;
                    if (drp != null)
                    {
                        // If we already have a selection then we don't want the Grids SelectionController to be called which will cause a capture of the mouse and prevent dragging.
                        if (drp.IsSelected)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
    
        }
    }
