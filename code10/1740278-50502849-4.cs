    public class FlyWeidhtFactory
    {
        Dictionary<string,IHou> dic = new Dictionary<string,IHou>();
        public IHou OperationInvoke<T>(string opClass)  where T: IHou 
        {
            Type type = typeof(T);
            string fullname = type.FullName;
            if(!dic.Contains(fullname)
            {
               Object obj = Activator.CreateInstance(type);
               dic[fullname] = (T)obj;  
               //no need of more cases 
            }
            return dic[opClass]; 
        }
    }
