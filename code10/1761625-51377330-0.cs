    var controlsToRemove = this.Controls.OfType<PictureBox>().ToArray();
    foreach (PictureBox pb in controlsToRemove)
    {
        Console.WriteLine(pb.Name);
        string x = pb.Name;
        this.Controls.Remove(pb);
        pb.Dispose();
    }
