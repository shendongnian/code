    public struct MyModel : IModel, IEquatable<MyModel>
    {
        /// <summary>
        /// Data constructor. Assumes data is initialized after this is called.
        /// </summary>
        /// <param name="a">The A value</param>
        /// <param name="b">The B value</param>
        public MyModel(int a, string b)
        {
            this.A = a;
            this.B = b;
            this.Initialized = true;
        }
        /// <summary>
        /// Copy construct, but with ability to flip the Initialized property
        /// </summary>
        /// <param name="other">The model to copy data from</param>
        /// <param name="initialized">Set the initialization flag here</param>
        public MyModel(MyModel other, bool initialized = true)
        {
            this = other;
            this.Initialized = initialized;
        }
        public int A { get; }
        public string B { get; }
        public bool Initialized { get; }
    }
    public class MyModelPlugin: IPlugin<MyModel>
    {
        public MyModel Model { get; private set; }
        public event ChangesAppliedDelegate<MyModel> ChangesApplied;
        public void SetData(MyModel model)
        {
            if(model.Initialized)
            {
                this.Model =model;
                ChangesApplied?.Invoke(Model);
            }
            else
            {
                // Handle case where model isn't initialized
            }
        }
    }
