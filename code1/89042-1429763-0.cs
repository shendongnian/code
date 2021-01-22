     protected static void BindCollection<T>(
            T list
            , ref T localVar
            , ref ListChangedEventHandler eh)
            where T : class, IBindingList
        {
            if (eh == null)
                eh = new ListChangedEventHandler(d);
            if (list != null && list != localVar)
            {
                if (localVar != null)
                    localVar.ListChanged -= eh;
                localVar = list;
                list.ListChanged += eh;
            }
            else if (localVar != null && list == null)
            {
                localVar.ListChanged -= eh;
                localVar = list;
            }
        }
    public override BindingList<ofWhatever> Children
        {
            get{//..}
            set
            {
               //woot! a one line complex setter 
               BindCollection(value, ref _Children, ref this.childrenChanged);
            }
        }
