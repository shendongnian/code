    class MyDependentItem : ObservableObject
    {
        public IMySubItem SubItem { get; } // where IMySubItem offers some NestedItem property
        
        [DependsOn(/* some reference to this.SubItem.NestedItem.Value*/)]
        public int DependentValue { get; }
        [DependsOn(/* some reference to GlobalSingleton.Instance.Value*/)]
        public int OtherValue { get; }
    }
