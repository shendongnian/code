    public class AcceptCommand : ModuleBase<SocketCommandContext>
    {
        [Command("Accept")]
        public async Task order([Remainder]string uniqueID)
        {
            if(SomeDictionaryOfAcceptedOrders.ContainsKey(uniqueID){
                //Someone already accepted
            } else {
                //Give it to the caller
                SomeDictionaryOfAcceptedOrders.Add(uniqueID, "Person accepting order"); 
            }
         }
    }
    public class OrderCommand : ModuleBase<SocketCommandContext>
    {
        [Command("Order")]
        public async Task order()
        {
            var uniqueID = //UUID, SomeRandomHashValue, Whatever that will be unique to this order;
            var embed = new EmbedBuilder();
            await Context.Channel.SendMessageAsync("<@&468001483099471883>");
            embed.WithAuthor("Order Available");
            embed.AddField("Unique Order ID", uniqueID, true);
            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
