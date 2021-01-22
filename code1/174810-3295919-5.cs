    private void Poll() {
        while (true) {
            var selected = (String) Dispatcher.Invoke((Func<String>) (() => (List.SelectedValue ?? "?").ToString()));
            var isChecked = (Boolean?) Dispatcher.Invoke((Func<Boolean?>) (() => Check.IsChecked));
            Debug.WriteLine(String.Format("List: {0}", selected));
            Debug.WriteLine(String.Format("Check: {0}", isChecked));
            Thread.Sleep(5000);
        }
    }
