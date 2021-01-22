[ValidationProperty("Foo")]
public class MyUserControl : UserControl
{
     public string Foo
     {
          get { return(yourDropDown.SelectedValue); }
     }
}
