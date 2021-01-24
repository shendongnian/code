    public class PromptDialogTextSpeak:PromptDialog
    {
        public static void Text(IDialogContext context, ResumeAfter<string> resume, IPromptOptions<string> promptOptions)
        {
            var child = new PromptString(promptOptions);
            context.Call<string>(child, resume);
        }
    }
