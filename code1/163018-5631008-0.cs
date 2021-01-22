    public class MeasuredParamEditor : CollectionEditor
    {
        public static EventHandler CollectionChanged;
        public MeasuredParamEditor(Type type)
            : base(type)
        { }
        protected override string GetDisplayText(object value)
        {
            if (value is MeasuredParam)
            {
                MeasuredParam param = (MeasuredParam)value;
                return string.Format("{0}: {1}", param.Name, param.Value);
            }
            else return base.GetDisplayText(value);
        }
        protected override CollectionForm CreateCollectionForm()
        {
            CollectionForm collectionForm = base.CreateCollectionForm();
            Form frm = collectionForm as Form;
            if (frm != null)
            {
                // Get OK button of the Collection Editor...
                Button button = frm.AcceptButton as Button;
                // Handle click event of the button
                button.Click += new EventHandler(OnCollectionChanged);
            }
            return collectionForm;
        }
        void OnCollectionChanged(object sender, EventArgs e)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(sender, e);
            }
        }
    }
