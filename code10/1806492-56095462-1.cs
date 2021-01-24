    public class MyDataGrid : DataGrid
    {
       // place-holder to keep if so needed to expand later
       IMyDataGridSource boundToObject;
    
       public MyDataGrid()
       {
          // Force this class to trigger itself after the control is completely loaded,
          // bound to whatever control and is ready to go
          Loaded += MyDataGrid_Loaded;
       }
    
       private void MyDataGrid_Loaded(object sender, RoutedEventArgs e)
       {
          // when the datacontext binding is assigned or updated, see if it is based on 
          // the IMyDataGridSource object.  If so, try to type-cast it and save into the private property
          // in case you want to add other hooks to it directly, such as mouseClick, grid row changed, etc...
          boundToObject = DataContext as IMyDataGridSource;
       }
       // OVERRIDE the DataGrid base class when items changed and the ItemsSource
       // list/binding has been updated with a new set of records    
       protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
       {
          // do whatever default behavior
          base.OnItemsChanged(e);
    
          // if the list is NOT bound to the data context of the IMyDataGridSource, get out
          if (boundToObject == null)
             return;
    
          // the bound data context IS of expected type... call method to rebuild column headers
          // since the "boundToObject" is known to be of IMyDataGridSource,
          // we KNOW it has the method... Call it and pass this (MyDataGrid) to it
          boundToObject.MyDataGridItemsChanged(this);
       }
    }
