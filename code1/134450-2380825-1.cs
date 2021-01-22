    public partial class MyWebPage : MyPage
    {
      protected void Page_Load(object sender, EventArgs e)
      {
        Foo myFoo = new Foo();
        Foo.Age = this.Age;
      }
    }
