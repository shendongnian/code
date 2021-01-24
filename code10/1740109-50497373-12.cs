    interface IRequest { }
    
    interface IRequest<T>:IRequest
    {
        T GenericParm { get; set; }
        int IntParm { get; set; }
    }
