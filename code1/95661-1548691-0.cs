    interface IHtmlRenderable
    {
        void RenderHtml();
    }
    
    void MyMethod(List<T> items) //where T implements IHtmlRenderable
    {
        foreach(T item in items) ((IHtmlRenderable)item).RenderHtml();
    }
