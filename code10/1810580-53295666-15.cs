    public interface IViewRender
    {
        string Render(string name);
        string Render<TModel>(string name, TModel model);
    }
