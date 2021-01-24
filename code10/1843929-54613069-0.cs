`
using Microsoft.WindowsAPICodePack.Dialogs;
...
private void Button_Click(object sender, RoutedEventArgs e)
{
    System.Threading.Tasks.Task.Factory.StartNew(() =>
    {
        Dispatcher.Invoke(() =>
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();
        });
    });
}
`
On the other hand, without using `Dispatcher.Invoke(...)` it fails with the following exception:
> System.InvalidOperationException: 'The calling thread cannot access
> this object because a different thread owns it.
