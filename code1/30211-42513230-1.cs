    class MyFileDialog
    {
        //https://msdn.microsoft.com/en-us/library/ms741870(v=vs.110).aspx
        //Article on Threading Model
        private delegate void OneArgStrDelegate(string str);
        private void MyExternalDialog(string extensions)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = extensions;
            fd.ShowDialog();
            tcs.SetResult(fd.FileName);
        }
        private TaskCompletionSource<string> tcs;
        public Task<string> ChooseFileFromExtension(string file_ext)
        {
            //Cf Puppet Task in Async in C#5.0 by Alex Davies
            tcs = new TaskCompletionSource<string>();
            OneArgStrDelegate fetcher = new OneArgStrDelegate(this.MyExternalDialog);
            fetcher.BeginInvoke(file_ext, null, null);
            return tcs.Task;
        }
    }
