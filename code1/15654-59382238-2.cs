    using System;
    using System.ComponentModel;
    using System.Data;
    public partial class MyComponent : Component
    {
        private const string DataSetComponentName = "dataSet";
        public DataSet DataSet
        {
            get => (DataSet)((DisposableWrapperComponent)components.Components[DataSetComponentName])
                    ?.Disposable;
            set
            {
                var lastWrapper = (DisposableWrapperComponent)components.Components[DataSetComponentName];
                if (lastWrapper != null)
                {
                    components.Remove(lastWrapper);
                    lastWrapper.Dispose();
                }
                if (value != null)
                {
                    components.Add(new DisposableWrapperComponent(value), DataSetComponentName);
                }
            }
        }
        public MyComponent(DataSet dataSet)
        {
            DataSet = dataSet ?? throw new ArgumentNullException(nameof(dataSet));
        }
    }
