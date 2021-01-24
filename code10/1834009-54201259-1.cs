    // Try this:
    // Don't call your class JSInterop
    public class MyJSInterop {
            public static async Task<string> ChangeText() {
                try {
                    var data = await JSRuntime.Current.InvokeAsync<string>("methods.print","mymessage");
                    Console.WriteLine($"ReturnedFromJS:{data}");
                    return data;
                } catch (Exception ex) {
    
                    return ex.Message;
                }
    
            }
        }
    
    // Js file
    window.methods = {
        print: function (message) {
            return "from js" + message;
        }
    }
