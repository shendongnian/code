    public class myTodo
       {
           /// <summary>
           /// web service/webmethod needs 0 parameter constructor
           /// </summary>
           public myTodo()
           {
           }
           public myTodo(int tdlId, string description)
           {
               TdlId= tdlId;
               Description= description;
           }
    
           public int TdlId;
           public string Description;
    
       }
