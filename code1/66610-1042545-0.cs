        public class MyPage : System.Web.UI.Page
        {
                public string Frasehiragana
                {
                    get
                    {
                        try{
                        return HttpContext.Current.Application.Contents["_Frasehiragana"] as string;
                        }
                        catch
                        {
                              return null;
                        }
                    }
                    set
                    {
                        HttpContext.Current.Application.Add("_Frasehiragana", value);
                    }
                }
        }
