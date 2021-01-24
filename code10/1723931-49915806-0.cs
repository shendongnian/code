    public class YourAttribute : IApplyStateFilter{
        public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
             if (context.NewState.IsFinal && context.NewState.Name == "Succeeded")
                //Send your message to client via signalR
        }}
