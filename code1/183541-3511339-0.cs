    public class MyCollectionEditor : CollectionEditor
    {
        // Inherit the default constructor from CollectionEditor
        public MyCollectionEditor(Type type) : base(type) { }
    
        // Override this method in order to access the containing user controls
        // from the default Collection Editor form or to add new ones...
        protected override CollectionForm CreateCollectionForm()
        {
            CollectionForm collectionForm = base.CreateCollectionForm();
            collectionForm.FormClosing += 
              new FormClosingEventHandler(collectionForm_FormClosing);
            // TODO: Look in collectionForm.Controls collection for other 
            // controls, and hook up to their validation events
            return collectionForm;
        }
    
        void collectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CollectionForm collectionForm = (CollectionForm)sender;
            DialogResult result = collectionForm.DialogResult;
            if (result == DialogResult.OK)
            {
              // TODO: Perform validation, and set e.Cancel 
            }
        }
    }
