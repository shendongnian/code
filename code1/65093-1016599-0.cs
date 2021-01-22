    [ComVisible(false)]
    public class ClassToHide {
        //whatever
    };
    public class ClassToExpose {
        [ComVisible(true)]
         public void MethodToExpose() {}
        [ComVisible(false)]
         public void MethodToHide() {}
    };
