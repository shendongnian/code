    public partial class MyComponent : System.ComponentModel.Component
    {
        private readonly System.Data.DataSet _dataSet;
        public MyComponent(System.Data.DataSet dataSet)
        {
            _dataSet = dataSet ?? throw new System.ArgumentNullException(nameof(dataSet));
            components.Add(new DisposableWrapperComponent(dataSet));
        }
    }
