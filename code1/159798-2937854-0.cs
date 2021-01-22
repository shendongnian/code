    public class MyWindow : UserControl{
    BindingList<MyObject> ObjectList = new BindingList<MyObject>;
        public MyWindow(){
            ObjectList.AllowAdd = true;
            ObjectList.AllowDelete = true;
            ObjectList.AllowEdit = true;
        }
        public void LoadObjects(){
           ThreadPool.QueryUserItem( (s)=>{
               // load your objects in list first in different thread
               List<MyObject> list = MyLongMethodToLoadObjects();
               Dispatcher.BeginInvoke( (Action)delegate(){
                   list.RaiseEvents = false;
                   foreach(MyObject obj in list){
                       ObjectList.Add(obj);
                   }
                   list.RaiseEvents = true;
                   list.ResetBindings();
               });
           });
        }
    }
