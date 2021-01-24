public class NewForm 
{ 
    public string Field { get; set; } 
    public bool Check { get; set; } 
}
Then, in your view (.cshtml file) you can create html inputs for them like so:
@Html.TextBoxFor(m => m.Field)
@Html.CheckBoxFor(m => m.Check)
Also, don't forget to reference your model at the top of the view (similar to other using statements in in normal C# classes) or else your view will not render properly.
