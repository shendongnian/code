    abstract public class BaseTemplate
    {
        abstract protected void MyFunc();
    }
    public class TemplateA : BaseTemplate
    {
        protected override void MyFunc()
        {
            DoSomething(this);
        }
    }
    public class TemplateB : BaseTemplate
    {
        protected override void MyFunc()
        {
            DoSomethingElse(this);
        }
    }
