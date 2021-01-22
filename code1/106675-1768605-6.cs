    class MyClass {
        public void MyMethod() {}
    }
    class UrlBuilder3<T> {
        Expression<Func<T, Action>> info;
        public UrlBuilder3(Expression<Func<T, Action>> info) {
            this.info = info;                
        }
        public override string ToString() {
            UnaryExpression exp = (UnaryExpression)info.Body;
            MethodCallExpression createDelegate = (MethodCallExpression)exp.Operand;
            // 0-Action,1-x,2-Delegate as Constant
            ConstantExpression methodArgument = (ConstantExpression)createDelegate.Arguments[2];
            MethodInfo method = (MethodInfo)methodArgument.Value;
            return string.Format("{0}/{1}.aspx", typeof(T).Name, method.Name);
        }
    }
    [Test]
    public void UrlByDelegate() {
        new UrlBuilder3<MyClass>(x => x.MyMethod).ToString()
            .Should().Be.EqualTo("MyClass/MyMethod.aspx");
    }
