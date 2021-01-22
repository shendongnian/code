        {
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background,
                (System.Windows.Threading.DispatcherOperationCallback)delegate(object arg)
                {
                    int N = fileList.Items.Count;
                    if (N == 0)
                        return null;
                    if (index < 0)
                    {
                        fileList.ScrollIntoView(fileList.Items[0]); // scroll to first
                    }
                    else
                    {
                        if (index < N)
                        {
                            fileList.ScrollIntoView(fileList.Items[index]); // scroll to item
                        }
                        else
                        {
                            fileList.ScrollIntoView(fileList.Items[N - 1]); // scroll to last
                        }
                    }
                    return null;
                }, null);
        }
