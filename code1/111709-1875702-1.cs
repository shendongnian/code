[Browsable(false),
    EditorBrowsable(EditorBrowsableState.Never),
    Bindable(false), 
    DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
public override string Text {
    get { return base.Text; }
    set { base.Text = value; }
}
* **Browsable** - whether the member shows up in the Properties window
* **EditorBrowsable** - whether the member shows up in the Intellisense dropdown
EditorBrowsable(false) won't prevent you from typing the property, and if you use the property, your project will still compile.  But since the property doesn't appear in Intellisense, it won't be as obvious that you can use it.
