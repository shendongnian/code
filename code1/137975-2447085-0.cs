    using(SvnClient client = new SvnClient())
    {
       client.Status(path,
                     delegate(object sender, SvnStatusEventArgs e)
                     {
                        if (e.LocalContentStatus == SvnStatus.Added)
                           Console.WriteLine("Added {0}", e.FullPath);
                     });
    }
