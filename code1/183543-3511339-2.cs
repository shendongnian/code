    public class MyCollectionEditor : CollectionEditor
    {
        private static Dictionary<CollectionForm, Button> okayButtons 
            = new Dictionary<CollectionForm, Button>();
        // Inherit the default constructor from CollectionEditor
        public MyCollectionEditor(Type type) 
            : base(type) 
        {
        }
        // Override this method in order to access the containing user controls
        // from the default Collection Editor form or to add new ones...
        protected override CollectionForm CreateCollectionForm()
        {
            CollectionForm collectionForm = base.CreateCollectionForm();
            collectionForm.FormClosed += 
                new FormClosedEventHandler(collectionForm_FormClosed);
            collectionForm.Load += new EventHandler(collectionForm_Load);
            if (collectionForm.Controls.Count > 0)
            {
                TableLayoutPanel mainPanel = collectionForm.Controls[0] 
                    as TableLayoutPanel;
                if ((mainPanel != null) && (mainPanel.Controls.Count > 7))
                {
                    // Get a reference to the inner PropertyGrid and hook 
                    // an event handler to it.
                    PropertyGrid propertyGrid = mainPanel.Controls[5] 
                        as PropertyGrid;
                    if (propertyGrid != null)
                    {
                        propertyGrid.PropertyValueChanged += 
                            new PropertyValueChangedEventHandler(
                                propertyGrid_PropertyValueChanged);
                    }
                    // Also hook to the Add/Remove
                    TableLayoutPanel buttonPanel = mainPanel.Controls[1] 
                        as TableLayoutPanel;
                    if ((buttonPanel != null) && (buttonPanel.Controls.Count > 1))
                    {
                        Button addButton = buttonPanel.Controls[0] as Button;
                        if (addButton != null)
                        {
                            addButton.Click += new EventHandler(addButton_Click);
                        }
                        Button removeButton = buttonPanel.Controls[1] as Button;
                        if (removeButton != null)
                        {
                            removeButton.Click += 
                                new EventHandler(removeButton_Click);
                        }
                    }
                    // Find the OK button, and hold onto it.
                    buttonPanel = mainPanel.Controls[6] as TableLayoutPanel;
                    if ((buttonPanel != null) && (buttonPanel.Controls.Count > 1))
                    {
                        Button okayButton = buttonPanel.Controls[0] as Button;
                        if (okayButton != null)
                        {
                            okayButtons[collectionForm] = okayButton;
                        }
                    }
                }
            }
            return collectionForm;
        }
        private static void collectionForm_FormClosed(object sender, 
            FormClosedEventArgs e)
        {
            CollectionForm collectionForm = (CollectionForm)sender;
            if (okayButtons.ContainsKey(collectionForm))
            {
                okayButtons.Remove(collectionForm);
            }
        }
        private static void collectionForm_Load(object sender, EventArgs e)
        {
            ValidateEditValue((CollectionForm)sender);
        }
        private static void propertyGrid_PropertyValueChanged(object sender,
            PropertyValueChangedEventArgs e)
        {
            ValidateEditValue((CollectionForm)sender);
        }
        private static void addButton_Click(object sender, EventArgs e)
        {
            Button addButton = (Button)sender;
            ValidateEditValue((CollectionForm)addButton.Parent.Parent.Parent);
        }
        private static void removeButton_Click(object sender, EventArgs e)
        {
            Button removeButton = (Button)sender;
            ValidateEditValue((CollectionForm)removeButton.Parent.Parent.Parent);
        }
        private static void ValidateEditValue(CollectionForm collectionForm)
        {
            if (okayButtons.ContainsKey(collectionForm))
            {
                Button okayButton = okayButtons[collectionForm];
                IList<MyClass> items = collectionForm.EditValue as IList<MyClass>;
                okayButton.Enabled = MyCollectionIsValid(items);
            }
        }
        private static bool MyCollectionIsValid(IList<MyClass> items)
        {
            // Perform validation here.
            return (items.Count == 2);
        }
    }
