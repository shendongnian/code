    public abstract class RendererOptionCheckbox : IOptionCheckbox
    {
        public IRenderer Renderer => new CheckboxRender();
        public abstract void OnValueChanged(bool newValue);
    }
