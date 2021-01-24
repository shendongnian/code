    class Program {
        static void Main(string[] args) {
            Test test = new Test();
            CustomAuthorizeAttribute customAuthorizeAttribute = (CustomAuthorizeAttribute)Attribute.GetCustomAttribute(typeof(Test), typeof(CustomAuthorizeAttribute));
            customAuthorizeAttribute.Test();
            Console.ReadKey();
        }
    }
    [CustomAuthorize(PermissionActions = PermissionAction.Add | PermissionAction.Delete)]
    public class Test {
        
    }
    
    public class CustomAuthorizeAttribute : Attribute {
        public PermissionAction PermissionActions { get; set; }
        public void Test() {
            if ((PermissionActions & PermissionAction.Add) == PermissionAction.Add) Console.WriteLine("Add");
            if ((PermissionActions & PermissionAction.Delete) == PermissionAction.Delete) Console.WriteLine("Delete");
            if ((PermissionActions & PermissionAction.Update) == PermissionAction.Update) Console.WriteLine("Update");
        }
    }
    public enum PermissionAction {
        Add = 1,
        Update = 2,
        Delete = 4
    }
