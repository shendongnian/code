       namespace ProjectInfo
        ....
         public class ProjectInfo:System.Web.UI.WebControls.WebParts.Web.part
         {
                .....
                private SPWeb _spWeb;
                private SPList _spList;
                private string _listName = "ProjectDocs";
                ......
         }
        public ProjectInfo()
         {
                .....
                    //Remove code in constructure function.
                    //_spWeb = SPContext.Current.Web;
                    //It show me a error here when i trace the code
                    //_spList = _spWeb.Lists[_listName]; 
                .....
         }
    
       protected override void CreateChildControls()
            {
             ....
               base.CreateChildControls();
    
                _spWeb = SPContext.Current.Web;
                _spList = _spWeb.Lists[_listName];
              ....
             }
