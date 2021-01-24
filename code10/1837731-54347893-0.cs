@(value?"True":"False")
@functions()
{
  [Parameter]
  protected bool value {get;set;}
  protected override void OnParametersSet()
  {
      Console.WriteLine("a parameter has changed");
  }
}
