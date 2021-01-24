    public class Screen {
    }
    public interface IWindowManager {
        bool? ShowDialog(object rootModel, object context = null, IDictionary<string, object> settings = null);
    }
    public class DialogService {
        private IWindowManager _dialogAPI;
        public DialogService(IWindowManager dialogAPI) {
            _dialogAPI = dialogAPI;
        }
        public virtual bool? ShowDialog(Screen dialog)
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settings.ResizeMode = ResizeMode.NoResize;
            return _dialogAPI.ShowDialog(dialog, null, settings);
        }
    }
