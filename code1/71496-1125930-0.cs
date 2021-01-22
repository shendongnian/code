        public class ParameterInfo
        {
          string _path;
          RadTreeNode _parent;
        }          
    
    if (!ThreadPool.QueueUserWorkItem(new WaitCallback(GetDirectories),  
                                 new ParameterInfo  
                                 {  
                                      _path = path,
                                      _parent e.Node
                                 }))  
                             {  
                               //should log, if a thread has not been created  
                             }  
        
         private void GetDirectories(ParameterInfo param)
            {
                var dirs = (new DirectoryInfo(param._path)).GetDirectories();
        
                Array.ForEach(dirs, d => BeginInvoke( new Action( () => AddNode(d.Name, d.FullName, param._parent) )));
            }
