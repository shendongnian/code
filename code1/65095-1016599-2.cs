    [ComVisible(false)]
    public class ClassToHide {
        //whatever
    };
    public class ClassToExpose {
         public void MethodToExpose() {}
         [ComVisible(false)]
         public void MethodToHide() {}
    };
