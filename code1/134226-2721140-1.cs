    public class ProjectedBindingList<Tsrc, Tdest> 
        : BindingList<Tdest>
    {
        private readonly BindingList<Tsrc> _src;
        private readonly Func<Tsrc, Tdest> _projection;
        public ProjectedBindingList(
            BindingList<Tsrc> source, 
            Func<Tsrc, Tdest> projection)
        {
            _projection = projection;
            _src = source;
            RecreateList();
            _src.ListChanged += new ListChangedEventHandler(_src_ListChanged);
        }
        private void RecreateList()
        {
            RaiseListChangedEvents = false;
            Clear();
            foreach (Tsrc item in _src)
                this.Add(_projection(item));
            RaiseListChangedEvents = true;
        }
        void _src_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    this.InsertItem(e.NewIndex, Proj(e.NewIndex));
                    break;
                case ListChangedType.ItemChanged:
                    this.Items[e.NewIndex] = Proj(e.NewIndex);
                    break;
                case ListChangedType.ItemDeleted:
                    this.RemoveAt(e.NewIndex);
                    break;
                case ListChangedType.ItemMoved:
                    Tdest movedItem = this[e.OldIndex];
                    this.RemoveAt(e.OldIndex);
                    this.InsertItem(e.NewIndex, movedItem);
                    break;
                case ListChangedType.Reset:
                    // regenerate list
                    RecreateList();
                    OnListChanged(e);
                    break;
                default:
                    OnListChanged(e);
                    break;
            }
        }
        Tdest Proj(int index)
        {
            return _projection(_src[index]);
        }
    }
