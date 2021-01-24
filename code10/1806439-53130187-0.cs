    public class MyViewController : ObjectViewController<DetailView, Contact> {
        protected override void OnActivated() {
            base.OnActivated();
            ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
        }
        void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e) {
            if (e.Object == View.CurrentObject) {
                // execute your business logic
            }
        }
        protected override void OnDeactivated() {
            base.OnDeactivated();
            ObjectSpace.ObjectChanged -= ObjectSpace_ObjectChanged;
        }
    }
 
