    class Program {
        static void Main(string[] args) {
            var mut = Expressions.GetMut<AccountController>(c => c.LogIn(new LogInModel(), ""));
            mut.HasAttribute<ExportModelStateAttribute>().ShouldBeTrue();
            var failmut = Expressions.GetMut<AccountController>(c => c.LogInFails());
            failmut.HasAttribute<ExportModelStateAttribute>().ShouldBeTrue();
            Console.ReadKey();
        }
    }
    public class ExportModelStateAttribute : Attribute { }
    public class ActionResult { }
    public class LogInModel { }
    public class AccountController {
        [ExportModelState]
        public ActionResult LogIn(LogInModel model, string s) {
            return new ActionResult();
        }
        public void LogInFails() {}
    }
    public static class Expressions {
        public static LambdaExpression GetMut<T>(Expression<Func<T>> func) { return func; }
        public static LambdaExpression GetMut<T>(Expression<Action<T>> func) { return func; }
        // Signature of my extension method:
        public static bool HasAttribute<TAttribute>(this LambdaExpression method) {
            if (method.Body.NodeType == ExpressionType.Call) {
                MethodCallExpression call = (MethodCallExpression)method.Body;
                return call.Method.GetCustomAttributes(typeof(TAttribute), true).Any();
            }
            return false;
        }
        public static void ShouldBeTrue(this bool obj) {
            Console.WriteLine(obj);
        }
    }
