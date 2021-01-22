    class UrlBuilder2<T> {
        private readonly Expression<Func<T, object>> callExpression;
        public UrlBuilder2(Expression<Func<T,object>> callExpression) {
            this.callExpression = callExpression;
        }
        public override string ToString() {
            MethodCallExpression call = (MethodCallExpression) callExpression.Body;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}/{1}.aspx", call.Object.Type.Name, call.Method.Name);
            var delimiter = "?";
            var formalParams = call.Method.GetParameters();
            for (int i = 0; i < formalParams.Length; i++) {
                var actual = call.Arguments[i];
                if (actual == null)
                    continue; // Do not put NULL to QueryString
                var formal = formalParams[i].Name;
                sb.AppendFormat("{0}{1}={2}", delimiter, formal, HttpUtility.HtmlEncode(actual.ToString()));
            }
            return sb.ToString();
        }
    }
    [Test]
    public void CanBuildUrlByClassAndMethodName() {
        var str = new UrlBuilder2<MyForm>(c => c.MyMethod()).ToString();
        str.Should().Be.EqualTo("MyForm/MyMethod.aspx");
    }
    [Test]
    public void CanBuildUrlByMethodWithParams() {
        var str = new UrlBuilder2<MyForm>(c => c.MethodWithParams(2, "hello")).ToString();
        str.Should().Be.EqualTo("MyForm/MyMethod.aspx?i=2&str=hello");
    }
