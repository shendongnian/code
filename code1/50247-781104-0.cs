     public class Book<APClass> : Book where APClass : APBase
            private DataTable Table ; // data
            public override IEnumerator GetEnumerator()
            {                        
                for (position = 0;  position < Table.Rows.Count;  position++)           
                     yield return APBase.NewFromRow<APClass>(Tabela.Rows[position], this.IsOffline);
            }
       ...
    
      
      public class APBase ...
      {
    	...
    	internal static T NewFromRow<T>(DataRow dr, bool offline) where T : APBase
            {
                
                Type t = typeof(T);
                ConstructorInfo ci;
    
                if (!ciDict.ContainsKey(t))
                {
                    ci = t.GetConstructor(new Type[1] { typeof(DataRow) });
                    ciDict.Add(t, ci);
                }
                else ci = ciDict[t];
                
                T result = (T)ci.Invoke(new Object[] { dr });
    
                if (offline)
                    result.drCache = dr;    
                 
                return result;
            }
