    public interface INavigator {
        void Redirect(string url);
    }
    public sealed class StandardNavigator {
        void INavigator.Redirect(string url) {
            Response.Redirect(url);
        }
    }
