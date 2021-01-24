    using System;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;
    namespace TextBot.Dialogs {
      [Serializable]
      public class RootDialog: IDialog {
        public async Task StartAsync(IDialogContext context) {
          await context.PostAsync("Welcome! This is the root dialog.");
          context.Wait(MessageReceivedAsync);
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable result) {
          var activity = await result as Activity;
          if (activity.Text == "other") {
            context.Call(new EchoDialog(), this.AfterChildDialogIsDone);
          } else {
            context.Wait(MessageReceivedAsync);
          }
        }
        private async Task AfterChildDialogIsDone(IDialogContext context, IAwaitable result) {
          context.Wait(MessageReceivedAsync);
        }
      }
      [Serializable]
      public class EchoDialog: IDialog {
        public async Task StartAsync(IDialogContext context) {
          await context.PostAsync("Hi there, this is Another dialog!");
          context.Done(true);
        }
      }
    }
