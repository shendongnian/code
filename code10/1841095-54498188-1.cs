string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "SOMEFILENAME.exe"); // We need our path to be global
private void button4_Click(object sender, EventArgs e)
{
    using (var client = new WebClient())
    {
        client.DownloadFileCompleted += client_DownloadFileCompleted; // Add our new event handler
        MessageBox.Show("File will start downloading");
        client.DownloadFileAsync(new Uri("GOOGLE DRIVE LINK"), path);
    }
}
private void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) // This is our new method!
{
    MessageBox.Show("File has been downloaded!");
    System.Diagnostics.Process.Start(path);
}
Our next problem: `client` is inside a using block. This is great for foreground downloads but if we do it asynchronously (that's what doing it in the background is called) your `client` will be dead as soon as the block is left which is immediately after the download has been **started**. So let's make our `client` global to be able to destroy it later on.
string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "SOMEFILENAME.exe");
WebClient client; // Here it is!
private void button4_Click(object sender, EventArgs e)
{
    client = new WebClient(); // Create a new client here
    client.DownloadFileCompleted += client_DownloadFileCompleted; // Add our new event handler
    MessageBox.Show("File will start downloading");
    client.DownloadFileAsync(new Uri("GOOGLE DRIVE LINK"), path);
}
private void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) // This is our new method!
{
    MessageBox.Show("File has been downloaded!");
    System.Diagnostics.Process.Start(path);
}
private void Form1_FormClosing(object sender, FormClosingEventArgs e)
{
    if (client != null)
        client.Dispose(); // We have to delete our client manually when we close the window or whenever you want
}
Now let's assume the user can press the button a second time before the download is completed. Our client would be overwritten then and the download would be canceled. So let's just ignore the button press if we're already downloading something and only create the new client if we don't have one. New code:
string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "SOMEFILENAME.exe");
WebClient client;
private void button4_Click(object sender, EventArgs e)
{
    if (client != null && client.IsBusy) // If the client is already downloading something we don't start a new download
            return;
    if (client == null) // We only create a new client if we don't already have one
    {
        client = new WebClient(); // Create a new client here
        client.DownloadFileCompleted += client_DownloadFileCompleted; // Add our new event handler
    }
    MessageBox.Show("File will start downloading");
    client.DownloadFileAsync(new Uri("GOOGLE DRIVE LINK"), path);
}
private void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) // This is our new method!
{
    MessageBox.Show("File has been downloaded!");
    System.Diagnostics.Process.Start(path);
}
private void Form1_FormClosing(object sender, FormClosingEventArgs e)
{
    if (client != null)
        client.Dispose(); // We have to delete our client manually when we close the window or whenever you want
}
Now that the boring part is done let's come to your problem: Viewing the progress in a progress bar. `WebClient` has got another event called `DownloadProgressChanged`. We can use it to update our progress bar.
Talking about progress bars: In Windows Forms you can create one by searching for `ProgressBar` in the tool bow window in Visual Studio. Then place it somewhere in your window. The `ProgressBar` component has a few properties which are important for its range. We're lucky, the default values are exactly what we need.
Our updated code (assuming your progress bar is called `progressBar1`:
string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "SOMEFILENAME.exe");
WebClient client;
private void button4_Click(object sender, EventArgs e)
{
    if (client != null && client.IsBusy) // If the client is already downloading something we don't start a new download
            return;
    if (client == null) // We only create a new client if we don't already have one
    {
        client = new WebClient(); // Create a new client here
        client.DownloadFileCompleted += client_DownloadFileCompleted;
        client.DownloadProgressChanged += client_DownloadProgressChanged; // Add new event handler for updating the progress bar
    }
    MessageBox.Show("File will start downloading");
    client.DownloadFileAsync(new Uri("GOOGLE DRIVE LINK"), path);
}
private void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) // This is our new method!
{
    MessageBox.Show("File has been downloaded!");
    System.Diagnostics.Process.Start(path);
}
private void Form1_FormClosing(object sender, FormClosingEventArgs e)
{
    if (client != null)
        client.Dispose(); // We have to delete our client manually when we close the window or whenever you want
}
private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) // NEW
{
    progressBar1.Value = e.ProgressPercentage;
}
#Notes:
1. You can create the `FormClosing` method by double clicking the `FormClosing` event in your window's property box.
2. Calling `client.Dispose()` is only necessary when your program doesn't exit after closing the window. In any other case you could get rid of the `FormClosing` stuff completely.
That's all finally. I hope this wasn't too long for you and I could help you. Feel free to ask for clarification. That's what comments are there for.
