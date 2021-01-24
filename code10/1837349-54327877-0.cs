<button onclick="Emit">Press me</button>
@functions(){
[Parameter] protected Action<string> Pressed {get;set;}
public void Emit()
{
  Pressed?.Invoke("Some String");
}
}
In Emit, you use a conditional to check if anyone is subscribed to the Action and Invoke it, passing in the parameters.
Don't forget, in the Parent, if you want the page to update, call StateHasChanged() in the "doSomething" method.
