    public class Context
    {
        public static Context Current { get; set; }
        static Context()
        {
            Current = new Context();
        }
        //The key method : I'm returning the document of the currently selected child windows or null if no windows are opened
        public PlanDocument Document
        {
            get { 
                var currentView =  Form.ActiveForm as IPlanViewer;
                if (currentView != null)
                    return currentView.Document;
                else
                    return null;
            }
        }
    }
