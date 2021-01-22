    namespace VerifyUserInfo {
        public class CustomActions {
            [CustomAction]
            public static ActionResult TryToLogin(Session session) {
                return ActionResult.Success;
            }
            public static ActionResult RegisterDevice(Session session) {
                return ActionResult.Success;
            }
        }
    }
