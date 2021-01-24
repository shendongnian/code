    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Deployment.WindowsInstaller;
    namespace CustomAction
    {
        public class CustomActions
        {
            [CustomAction]
            public static ActionResult CustomAction(Session session)
            {
                session.Log("Begin CustomAction");
                return ActionResult.Success;
            }
        }
    }
