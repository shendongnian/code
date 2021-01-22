    enum Status
    {
     Empty = 'E',
     Updated = 'U'
    }
    void Main()
    {
     Status status = Status.Empty;
     Console.WriteLine("{0}: {1}", status, (char)status);
    }
