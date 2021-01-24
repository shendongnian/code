             public class AllUsers : ModuleBase<SocketCommandContext>
              {
                public async Task Traitement()
                {
                 var users = Context.Guild.Users; 
                 //you can loop here on users and do the traitement
                }
              }
