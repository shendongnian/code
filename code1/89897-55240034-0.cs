    class EasyAccordionToolboxService : AccordionControl, IToolboxService
    {
        EasyAccordionControlElement _SelectedElement;
        public Control DesignPanel { get; set; }
        public EasyAccordionToolboxService()
        {
            AddAccordions();
            AllowItemSelection = true;
            base.ElementClick += EasyAccordionToolboxService_ElementClick;
        }
        private void EasyAccordionToolboxService_ElementClick(object sender, ElementClickEventArgs e)
        {
            if (e.Element.Level == 1) this._SelectedElement = e.Element as EasyAccordionControlElement;
        }
        public ToolboxItem GetSelectedToolboxItem()
        {
            if(_SelectedElement != null)
            {
                var selectedToolboxItem = this._SelectedElement.ToolBoxItem;
                this._SelectedElement = null;
                return selectedToolboxItem;
            }
            else
            {
                return null;
            }
        }
            public bool SetCursor()
        {
            if(this._SelectedElement == null)
            {
                this.DesignPanel.Cursor = Cursors.Default;
            }
            else
            {
                this.DesignPanel.Cursor = Cursors.Hand;
            }
            return true;
        }
