        public class NoPromptService : PromptService
        {
            public override void Alert(string dialogTitle, string text)
            {
                log.Warn(dialogTitle, new Exception(text));
                if (text.EndsWith("could not be found. Please check the name and try again."))
                {
                    // Do Whatever
                }
            }
        }
