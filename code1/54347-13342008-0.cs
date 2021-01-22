     /// <summary>
     /// A <see cref="Behavior{T}"/> implementation which will automatically resize the automatic columns of a <see cref="ListView">ListViews</see> <see cref="GridView"/> to the new content.
     /// </summary>
     public class GridViewColumnResizeBehaviour : Behavior<ListView>
     {
          /// <summary>
          /// Listens for when the <see cref="ItemsControl.Items"/> collection changes.
          /// </summary>
          protected override void OnAttached()
          {
              base.OnAttached();
              
              var listView = AssociatedObject;
              if (listView == null)
                  return;
              
              AddHandler(listView.Items);
          }
          
          private void AddHandler(INotifyCollectionChanged sourceCollection)
          {
              Contract.Requires(sourceCollection != null);
              
              sourceCollection.CollectionChanged += OnListViewItemsCollectionChanged;
          }
          
          private void RemoveHandler(INotifyCollectionChanged sourceCollection)
          {
              Contract.Requires(sourceCollection != null);
              
              sourceCollection.CollectionChanged -= OnListViewItemsCollectionChanged;
          }
          
          private void OnListViewItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
          {
              var listView = AssociatedObject;
              if (listView == null)
                  return;
              
              var gridView = listView.View as GridView;
              if (gridView == null)
                  return;
              
              // If the column is automatically sized, change the column width to re-apply automatic width
              foreach (var column in gridView.Columns.Where(column => Double.IsNaN(column.Width)))
              {
                   Contract.Assume(column != null);
                   column.Width = column.ActualWidth;
                   column.Width = Double.NaN;
              }
          }
          
          /// <summary>
          /// Stops listening for when the <see cref="ItemsControl.Items"/> collection changes.
          /// </summary>
          protected override void OnDetaching()
          {
              var listView = AssociatedObject;
              if (listView != null)
                  RemoveHandler(listView.Items);
              
              base.OnDetaching();
          }
     }
