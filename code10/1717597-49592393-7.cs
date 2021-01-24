    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    namespace WpfApp
    {
    	public class TestData
	    {
		    public string Prop1 { get; set; }
		    public string Prop2 { get; set; }
		    public string Prop3 { get; set; }
	    }
	    public partial class MainWindow : Window
	    {
		    ObservableCollection<TestData> Data = new ObservableCollection<TestData>();
		    public MainWindow()
		    {
                //Get some data
			    Data.Add(new TestData { Prop1 = "Column11", Prop2 = "Column12", Prop3 = "Column13" });
			    Data.Add(new TestData { Prop1 = "Column21", Prop2 = "Column22", Prop3 = "Column23" });
			    Data.Add(new TestData { Prop1 = "Column31", Prop2 = "Column32", Prop3 = "Column33" });
			    Data.Add(new TestData { Prop1 = "Column41", Prop2 = "Column42", Prop3 = "Column43" });
			    InitializeComponent();
                //assign our collection to the Window DataContext
			    DataContext = Data;
		    }
            //this is where all the magic happens
		    private void DataGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		    {
			    DataGrid dataGrid = sender as DataGrid;
			    DataGridRow row = findParentOfType<DataGridRow>(e.OriginalSource as DependencyObject);
			    if(dataGrid != null && row != null)
			    {
				    //the row DataContext is the selected item
				    if(dataGrid.SelectedItems.Contains(row.DataContext))
				    {
					    dataGrid.SelectedItems.Remove(row.DataContext);
					    //mark event as handled so that datagrid does not      
                        //just select it again on the current click.
					    e.Handled = true;
				    }
			    }
		    }
            //This helper is used to find your target, which in your case is a DataGridRow.
            //In general, if you continue with WPF, I would suggest adding
            //this very handy method to your extensions library.
		    private T findParentOfType<T>(DependencyObject source) where T : DependencyObject
		    {
			    T ret = default(T);
			    UIElement parent = VisualTreeHelper.GetParent(source) as UIElement;
			    if (parent != null)
			    {
				    ret = parent as T ?? findParentOfType<T>(parent) as T;
			    }
			    return ret;
		    }
	    }
    }
