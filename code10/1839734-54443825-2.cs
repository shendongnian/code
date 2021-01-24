    interface ITemplate<out T> where T : TemplateDataBase
    {
        Type DataType { get; }
    }
    
    class TemplateBase<T> : ITemplate<T> where T : TemplateDataBase
    {
        public Type DataType => typeof(T);
    }
    
    class TemplateDataBase { }
    
    class TemplateEngine
    {
        public T GetTemplate<T>() where T : ITemplate<TemplateDataBase>, new()
        {
            var template = new T();
            return template;
        }
    }
    
    class SampleTemplate : TemplateBase<SampleTemplateData> { }
    
    class SampleTemplateData : TemplateDataBase { }
