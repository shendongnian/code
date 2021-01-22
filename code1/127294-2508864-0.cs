    TemplateField tf = new TemplateField();
    //Do some config like headertext, style, etc;
    tf.ItemTemplate = new CompiledTemplateBuilder(delegate(Control container)
    {
       //Add the regular row here, probably use a Label or Literal to show content
       Label label = new Label();
       lable.DataBinding += delegate(object sender, EventArgs e)
       {
            label.Text = ((MyDataType)DataBinder.GetDataItem(label.BindingContainer)).MyLabelDataField;
       };
    });
    tf.EditItemTemplate = new CompiledBindableTemplateBuilder(delegate(Control container)
    {
       //Here we do the edit row.  A CompiledBindableTemplateBuilder lets us bind in both directions
       TextBox text = new TextBox();
       text.DataBound += delegate(object sender, EventArgs e)
       {
           text.Text = ((MyDataType)DataBinder.GetDataItem(text.BindingContainer)).MyLabelDataField;
       }
    },
    delegate(Control container)
    {
       OrderedDictionary dict = new OrderedDictionary();
       dict["myLabelDataColumn"] = ((TextBox)container.FindControl(text.ID)).Text;
       return dict;
    });
