    private void button_Click(object sender, RoutedEventArgs e)
    {
        Task.Run(() => SomeLongRunningCode(out strstr));
    }
    public void SomeLongRunningCode(out string SomeProperty)
    {
        for (int i = 1; i <= 600; i++)
        {
            SomeLocalString = i.ToString();
            objClass.X = _someLocalString;
            Thread.Sleep(100);   // Slowing down so we can see the text change
        }
            SomeProperty = "Exited SomeLongRunningCode";
    }
