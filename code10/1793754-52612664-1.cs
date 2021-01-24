    using System.Threading.Tasks;
    using Flurl.Http;
    
    namespace MyApp.Services {
    
        public class ApiService {
            public static async Task<string> GetStringAsync() {
               return await "https://api.com".GetJsonAsync<string>();
            }
    
        }
    }
    
    // In your code behind 
    async void CallApi_Tapped( object sender, EventArgs e ) {
        var returnedString = await ApiService.GetStringAsync();
    }
    // Or in a view model via a command
    Command _doGetString;
    public Command DoGetString => _doGetString ?? ( _doGetString = new Command( async () => {
        var returnedString = await ApiService.GetStringAsync();
    } ) );
