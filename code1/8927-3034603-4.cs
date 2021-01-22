    public interface INavigator {
        void Redirect(string url);
    }
    public sealed class StandardNavigator : INavigator {
        void INavigator.Redirect(string url) {
            Response.Redirect(url);
        }
    }
