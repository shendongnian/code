    interface IRequest
    {
        string StringParm { get; set; }
        int IntParm { get; set; }
    }
    
    interface IRequest<T> { }
