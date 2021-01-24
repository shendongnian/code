    public class UssdRenderer : IUssdRenderer
    {
        public Android.Net.Uri createUriFromString(string ussd)
        {
            String uri = "tel:";
            foreach (char c in ussd.ToCharArray())
            {
                if (c == '#')
                {
                    uri += Android.Net.Uri.Encode("#");
                }
                else
                {
                    uri += c;
                }
            }
            return Android.Net.Uri.Parse(uri);
        }
        public void StartTransaction()
        {
            var intent = new Intent(Intent.ActionCall, createUriFromString("*270#"));
            Context ctx = Xamarin.Forms.Forms.Context;
            ctx.StartActivity(intent);
        }
    }
    }
