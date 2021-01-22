    ...
    client.DownloadStringCompleted += Foo;
    }
    void Foo(object sender, EventArgs args)
    {
        if (args.Error == null && !args.Cancelled)
        {
            MessageBox.Show();
        }
    };
