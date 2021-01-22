private void test_SourceUpdated(object sender, DataTransferEventArgs e)
{
    TextBox t = sender as TextBox;
    t.ScrollToEnd();
    t.Dispatcher.Invoke(new EmptyDelegate(() => { }), System.Windows.Threading.DispatcherPriority.Render);
}
