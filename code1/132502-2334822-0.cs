public class MyPresenter
{
  ... other code here
 
  public DoSomething()
  {
    IList<MyData> data = GetSomeData();
    myView.DisplayData(data);
  }
}
