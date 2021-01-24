    class TemplateEngine
    {
        public T GetTemplate<T>() where T : ITemplate<TemplateDataBase>, new()
        {
            var template = new T();
            return template;
        }
    }
    
    interface ITemplate<out T> where T : TemplateDataBase
    {
        string DataName { get; }
    }
    
    class TemplateBase<T> : ITemplate<T> where T : TemplateDataBase
    {
        public string DataName => typeof(T).Name;
    }
    
    class TemplateDataBase { }
    
    class SampleTemplate : TemplateBase<SampleTemplateData> { }
    
    class SampleTemplateData : TemplateDataBase { }
