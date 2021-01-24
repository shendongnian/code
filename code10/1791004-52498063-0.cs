    public abstract class BaseApiModel<T> {
        ...
        public abstract T FromJson(string json);
    }
    public class ContactApiModel : BaseApiModel<ContactApiModel> {
        ...
        public override ContactApiModel FromJson(string json) {
            [...return deserialized object...]
        }
    }
