    namespace My.Web.UI  
    {  
        public abstract class CustomControl : CompositeControl  
        {
            // ...
            public abstract void Initialize();
            protected override void CreateChildControls()
            {
                base.CreateChildControls();
                // Anything custom
                this.Initialize();
            }
        }
    }
