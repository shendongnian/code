    class Program {
        static void Main(string[] args) {
            int result = 2; // gives warning from your question
            var back = ExtractOutValue(s => int.TryParse(s, out result));           
            Debug.Assert(back == result);
        }
        static int ExtractOutValue(Expression<Action<string>> exp) {
            var call = (MethodCallExpression)exp.Body;            
            var arg = (MemberExpression) call.Arguments[1];
            return (int) ((FieldInfo)arg.Member).GetValue(((ConstantExpression)arg.Expression).Value);            
        }        
    }
