    public interface IProcessContext
    {
        // Hopefully you're using more descriptive names than these in your actual code...
        FileInfo File { get; set; }
        DateTime S { get; set; }
        DateTime D { get; set; }
        int Id { get; set; }
    }
