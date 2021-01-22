    public abstract class MyBaseController {
        public void Authenticate() { var r = GetRepository(); }
        public abstract void GetRepository();
    }
    public class ApplicationSpecificController {
        public override void GetRepository() { /*get the specific repo here*/ }
    }
