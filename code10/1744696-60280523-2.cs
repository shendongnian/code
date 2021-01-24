    [assembly: ExportRenderer(typeof(MyListView), typeof(MyListViewRenderer))]
    namespace MyApp
    {
        class MyListViewRenderer : ListViewRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
            {
                base.OnElementChanged(e);
                if (Control is Windows.UI.Xaml.Controls.ListView listView)
                {
                    listView.ItemContainerStyle = (Windows.UI.Xaml.Style)MyApp.App.Current.Resources["CustomListViewItem"];
                }
            }
        }
    }
