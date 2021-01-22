    public abstract class BasePage:Page 
    { 
        abstract protected Label Foo {get;}
        public void DoSomethingWithDerivedPageControl() 
        { 
            Control foo = this.Foo;
        } 
    } 
     
    public class DerivedPage : BasePage 
    { 
        override protected Label Foo { get; set;} 
    } 
