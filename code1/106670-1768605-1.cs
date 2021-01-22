    class UrlBuilder2<T> {
        private readonly Expression<Func<T, object>> callExpression;
        public UrlBuilder2(Expression<Func<T,object>> callExpression) {
            this.callExpression = callExpression;
        }
        public override string ToString() {
            MethodCallExpression call = (MethodCallExpression) callExpression.Body;
            return string.Format("{0}/{1}.aspx", call.Object.Type.Name, call.Method.Name);
        }
    }
    [Test]
    public void CanBuildUrlByClassAndMethodName() {
        var str = new UrlBuilder2<MyForm>(c => c.MyMethod()).ToString();
        str.Should().Be.EqualTo("MyForm/MyMethod.aspx");
    }
