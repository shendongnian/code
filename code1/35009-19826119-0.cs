        [System.ComponentModel.DesignerCategory("Code")]
    public class MyTabPage : TabPage
    {
        private TabControl _parent;
        private bool _isVisible;
        private int _index;
        public new bool Visible
        {
            get { return _isVisible; }
            set
            {
                if (_parent == null) _parent = this.Parent as TabControl;
                if (_parent == null) return;
                if (_index < 0) _index = _parent.TabPages.IndexOf(this);
                if (value && !_parent.TabPages.Contains(this))
                {
                    if (_index >= 0) _parent.TabPages.Insert(_index, this);
                    else _parent.TabPages.Add(this);
                }
                else if (!value && _parent.TabPages.Contains(this)) _parent.TabPages.Remove(this);
                _isVisible = value;
                base.Visible = value;
            }
        }
        protected override void InitLayout()
        {
            base.InitLayout();
            _parent = Parent as TabControl;
        }
    }
