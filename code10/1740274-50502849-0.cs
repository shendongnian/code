    public class FlyWeidhtFactory
    {
      Dictionary<string,IHou> dic = new Dictionary<string,IHou>();
        public override IHou OperationInvoke(string opClass)
        {
            if(!dic.Contains(opClass)
            {
             if(opClass == "T")
             {
               dic[opClass] = new Treasure ();   
             }
            }
            return dic[opClass]; 
        }
    }
