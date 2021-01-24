    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Schema;
    
    namespace HotelBot
    {
        //Reference: TextPrompt.cs
        public class CustomPrompt : Prompt2<string>
        {
            public CustomPrompt(string dialogId, PromptValidator<string> validator = null)
                : base(dialogId, validator)
            {
            }
    
            protected async override Task OnPromptAsync(ITurnContext turnContext, IDictionary<string, object> state, PromptOptions options, bool isRetry, CancellationToken cancellationToken = default(CancellationToken))
            {
                if (turnContext == null)
                {
                    throw new ArgumentNullException(nameof(turnContext));
                }
    
                if (options == null)
                {
                    throw new ArgumentNullException(nameof(options));
                }
    
                if (isRetry && options.RetryPrompt != null)
                {
                    await turnContext.SendActivityAsync(options.RetryPrompt, cancellationToken).ConfigureAwait(false);
                }
                else if (options.Prompt != null)
                {
                    await turnContext.SendActivityAsync(options.Prompt, cancellationToken).ConfigureAwait(false);
                }
            }
    
            protected override Task<PromptRecognizerResult<string>> OnRecognizeAsync(ITurnContext turnContext, IDictionary<string, object> state, PromptOptions options, CancellationToken cancellationToken = default(CancellationToken))
            {
                if (turnContext == null)
                {
                    throw new ArgumentNullException(nameof(turnContext));
                }
    
                var result = new PromptRecognizerResult<string>();
                if (turnContext.Activity.Type == ActivityTypes.Message)
                {
                    var message = turnContext.Activity.AsMessageActivity();
                    if (!string.IsNullOrEmpty(message.Text))
                    {
                        result.Succeeded = true;
                        result.Value = message.Text;
                    }
                    /*Add handling for Value from adaptive card*/
                    else if (message.Value != null)
                    {
                        result.Succeeded = true;
                        result.Value = message.Value.ToString();
                    }
                }
    
                return Task.FromResult(result);
            }
        }
    }
